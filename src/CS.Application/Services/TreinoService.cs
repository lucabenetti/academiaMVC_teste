using CS.Application.Interface;
using CS.Application.Model;
using CS.Application.Response;
using CS.Core.Notificador;
using CS.Data.Interface;
using CS.Domain.Entidades;

namespace CS.Application.Services
{
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _treinoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IExercicioRepository _exercicioRepository;
        private readonly INotificador _notificador;

        public TreinoService(ITreinoRepository treinoRepository,
            IAlunoRepository alunoRepository,
            IExercicioRepository exercicioRepository,
            INotificador notificador)
        {
            _treinoRepository = treinoRepository;
            _alunoRepository = alunoRepository;
            _exercicioRepository = exercicioRepository;
            _notificador = notificador;
        }

        public async Task<Guid?> Adicionar(TreinoModel model)
        {
            if (model == null)
            {
                _notificador.AdicionarNotificacao("Dados inválidos");
                return null;
            }

            if (!(await model.EhValido()))
            {
                _notificador.AdicionarNotificacoes(await model.ObterErros());
                return null;
            }

            var treinoJaExistente = await _treinoRepository.ObterPorDiaEAluno(model.AlunoId, model.DiaDaSemana);

            if (treinoJaExistente is not null)
            {
                _notificador.AdicionarNotificacao("Treino já existente para dia da semana");
                return null;
            }

            var aluno = await _alunoRepository.ObterPorId(model.AlunoId);
            if (aluno is null)
            {
                _notificador.AdicionarNotificacao("Id de aluno inválido");
                return null;
            }

            var exercicios = new List<Exercicio>();
            foreach (var exercicioId in model.ExerciciosId)
            {
                var exercicio = await _exercicioRepository.ObterPorId(exercicioId);
                if (exercicio is null)
                {
                    _notificador.AdicionarNotificacao("Id de exercício inválido");
                    return null;
                }

                exercicios.Add(exercicio);
            }

            var treino = new Treino()
            {
                Aluno = aluno,
                Exercicios = exercicios,
                DiaDaSemana = model.DiaDaSemana
            };

            await _treinoRepository.Adicionar(treino);
            await _treinoRepository.CommitAsync();

            return treino.Id;
        }

        public async Task Remover(RemoverEntidadeModel model)
        {
            var treino = await _treinoRepository.ObterPorId(model.Id);

            if (treino is null)
            {
                _notificador.AdicionarNotificacao("Id inválido");
                return;
            }

            _treinoRepository.Remover(treino);
            await _treinoRepository.CommitAsync();
        }

        public async Task Atualizar(TreinoModel model)
        {
            var treino = await _treinoRepository.ObterPorId(model.Id);
            if (treino is null)
            {
                _notificador.AdicionarNotificacao("Id de treino inválido");
                return;
            }

            var exercicios = new List<Exercicio>();
            foreach (var exercicioId in model.ExerciciosId)
            {
                var exercicio = await _exercicioRepository.ObterPorId(exercicioId);
                if (exercicio is null)
                {
                    _notificador.AdicionarNotificacao("Id de exercício inválido");
                    return;
                }

                exercicios.Add(exercicio);
            }

            var aluno = await _alunoRepository.ObterPorId(treino.AlunoId);
            var novoTreino = new Treino()
            {
                Aluno = aluno,
                Exercicios = exercicios,
                DiaDaSemana = model.DiaDaSemana
            };

            _treinoRepository.Remover(treino);
            await _treinoRepository.Adicionar(novoTreino);
            await _treinoRepository.CommitAsync();
        }

        public async Task<TreinoResponse> ObterPorId(Guid id)
        {
            var treino = await _treinoRepository.ObterPorId(id);

            if (treino is null)
            {
                _notificador.AdicionarNotificacao("Id inválido");
                return null;
            }

            var aluno = treino.Aluno;

            return new TreinoResponse()
            {
                Id = treino.Id,
                DiaDaSemana = treino.DiaDaSemana,
                Aluno = new AlunoResponse()
                {
                    Id = aluno.Id,
                    Email = aluno.Usuario.Email,
                    Cpf = aluno.Cpf,
                    DataNascimento = aluno.DataNascimento,
                    Nome = aluno.Nome,
                    Altura = aluno.Altura,
                    Peso = aluno.Peso,
                    Endereco = new EnderecoResponse()
                    {
                        Cidade = aluno.Endereco.Cidade,
                        Numero = aluno.Endereco.Numero,
                        Bairro = aluno.Endereco.Bairro,
                        CEP = aluno.Endereco.CEP,
                        Complemento = aluno.Endereco.Complemento,
                        Estado = aluno.Endereco.Estado,
                        Logradouro = aluno.Endereco.Logradouro
                    }
                },
                Exercicios = treino.Exercicios.Select(x => new ExercicioResponse()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    GrupoCorporal = x.GrupoCorporal,
                    QuantidadeRepeticao = x.QuantidadeRepeticao,
                    Restricao = x.Restricao,
                    TipoExercicio = x.TipoExercicio
                })
            };
        }

        public async Task<List<TreinoResponse>> Obter()
        {
            var treinos = await _treinoRepository.Obter();

            return treinos.Select(treino => new TreinoResponse()
            {
                Id = treino.Id,
                DiaDaSemana = treino.DiaDaSemana,
                Aluno = new AlunoResponse()
                {
                    Id = treino.Aluno.Id,
                    Email = treino.Aluno.Usuario.Email,
                    Cpf = treino.Aluno.Cpf,
                    DataNascimento = treino.Aluno.DataNascimento,
                    Nome = treino.Aluno.Nome,
                    Altura = treino.Aluno.Altura,
                    Peso = treino.Aluno.Peso,
                    Endereco = new EnderecoResponse()
                    {
                        Cidade = treino.Aluno.Endereco.Cidade,
                        Numero = treino.Aluno.Endereco.Numero,
                        Bairro = treino.Aluno.Endereco.Bairro,
                        CEP = treino.Aluno.Endereco.CEP,
                        Complemento = treino.Aluno.Endereco.Complemento,
                        Estado = treino.Aluno.Endereco.Estado,
                        Logradouro = treino.Aluno.Endereco.Logradouro
                    }
                },
                Exercicios = treino.Exercicios.Select(x => new ExercicioResponse()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    GrupoCorporal = x.GrupoCorporal,
                    QuantidadeRepeticao = x.QuantidadeRepeticao,
                    Restricao = x.Restricao,
                    TipoExercicio = x.TipoExercicio
                })
            }).ToList();
        }

        public async Task<TreinoResponse> ObterPorDia(Guid alunoId)
        {
            var diaDaSemana = DateTime.Now.DayOfWeek;

            var treino = await _treinoRepository.ObterPorDiaEAluno(alunoId, diaDaSemana);

            if (treino is null) return null;

            var aluno = treino.Aluno;
            return new TreinoResponse()
            {
                Id = treino.Id,
                DiaDaSemana = treino.DiaDaSemana,
                Aluno = new AlunoResponse()
                {
                    Id = aluno.Id,
                    Email = aluno.Usuario.Email,
                    Cpf = aluno.Cpf,
                    DataNascimento = aluno.DataNascimento,
                    Nome = aluno.Nome,
                    Altura = aluno.Altura,
                    Peso = aluno.Peso,
                    Endereco = new EnderecoResponse()
                    {
                        Cidade = aluno.Endereco.Cidade,
                        Numero = aluno.Endereco.Numero,
                        Bairro = aluno.Endereco.Bairro,
                        CEP = aluno.Endereco.CEP,
                        Complemento = aluno.Endereco.Complemento,
                        Estado = aluno.Endereco.Estado,
                        Logradouro = aluno.Endereco.Logradouro
                    }
                },
                Exercicios = treino.Exercicios.Select(x => new ExercicioResponse()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    GrupoCorporal = x.GrupoCorporal,
                    QuantidadeRepeticao = x.QuantidadeRepeticao,
                    Restricao = x.Restricao,
                    TipoExercicio = x.TipoExercicio
                })
            };
        }
    }
}
