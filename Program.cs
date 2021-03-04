using System;
using cadastro_de_series;

namespace cadastro_de_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços:");
            Console.ReadLine();
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.WriteLine("Digite o id da série a ser excluido: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o id da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Ano início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da Série: ");
            String entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Séries Disponivel:");
            Console.WriteLine("---------------------------");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série foi encontrada");
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova Série:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da série: ");
            String entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de Início da Série :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série :");
            string EntradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: EntradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Séries Disponiveis para você");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            String opçaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opçaoUsuario;
        }
    }
}
