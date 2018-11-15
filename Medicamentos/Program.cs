using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projeto_Medicamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Medicamentos listaMedicamentos;
            listaMedicamentos = new Medicamentos();

            Medicamento m1 = new Medicamento();
            Queue<Lote> lotes = new Queue<Lote>();

            #region processo
            int op;
            do
            {
                Console.Clear();
               
                Console.WriteLine("0. Finalizar");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento sintético");
                Console.WriteLine("3. Consultar medicamento analítico");
                Console.WriteLine("4. Comprar medicamento");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.WriteLine("7. Deletar medicamento");

                Console.WriteLine("Escolha a opção desejada: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        int idMain; string nomeMain, nomeLaboratorio;
                        Console.WriteLine("Informe o ID do medicamento: ");
                        idMain = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o Nome do Medicamento: ");
                        nomeMain = Console.ReadLine();

                        Console.WriteLine("Informe o Nome do Laboratorio: ");
                        nomeLaboratorio = Console.ReadLine();

                        listaMedicamentos.adicionar(new Medicamento(idMain, nomeMain, nomeLaboratorio));
                        break;

                    case 2:

                        Console.WriteLine("Informe o ID: ");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;

                        Medicamento medPesqSint;
                        medPesqSint = listaMedicamentos.pesquisar(new Medicamento(idMain, "", ""));

                        if (medPesqSint.Id.Equals(""))
                        {
                            Console.WriteLine("ID não encontrado!");
                            Console.ReadKey();
                        }
                        else
                            Console.WriteLine(medPesqSint.ToString());
                            Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Informe o ID: ");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        Medicamento medPesqAnalit;
                        medPesqAnalit = listaMedicamentos.pesquisar(m1);
                        Console.WriteLine(medPesqAnalit.ToString());
                        
                        foreach (Lote lt in medPesqAnalit.GetLotes())
                        {
                            if (idMain.Equals(lt.Id))
                            {                               
                                Console.WriteLine(lt.LoteMed());
                            }                 
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        int id, qtde;
                        DateTime dataVenc;
                        Console.WriteLine("Informe o ID do medicamento: ");
                        idMain = Int32.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        Medicamento pesquisa = listaMedicamentos.pesquisar(m1);
                        Console.WriteLine("Digite o código do lote:");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite a quantidade de medicamento desejado:");
                        qtde = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a data de validade do lote:");
                        dataVenc = DateTime.Parse(Console.ReadLine());
                        Lote lo = new Lote(id, qtde, dataVenc);
                        pesquisa.comprar(lo);

                        Console.ReadKey();
                        break;

                    case 5:
                        int qtdeMedicamento, idMedicamento;
                        Console.WriteLine("Informe o ID do medicamento: ");
                        idMedicamento = int.Parse(Console.ReadLine());
                        Console.WriteLine("Informe a quantidade de venda: ");
                        qtdeMedicamento = int.Parse(Console.ReadLine());

                        Medicamento medicamentoEncontrado = listaMedicamentos.pesquisar(new Medicamento(idMedicamento, "", ""));
                        listaMedicamentos.MeusMedicamentos.ElementAt(idMedicamento).vender(qtdeMedicamento);

                        Console.ReadKey();
                        break;

                    case 6:
                        foreach (Medicamento med in listaMedicamentos.MeusMedicamentos)
                        {
                            Console.WriteLine(med.ToString());
                        }

                        Console.ReadKey();
                        break;
                    case 7:
                        Console.WriteLine("Informe o ID do medicamento: ");
                        idMain = int.Parse(Console.ReadLine());
                        m1.Id = idMain;
                        if(m1.qtdeDisponivel() > 0)
                        {
                            Console.WriteLine("Sem medicamento!");
                        }
                        else { 

                        listaMedicamentos.deletar(m1);
                            }

                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("");

                        Console.ReadKey();
                        break;


                }
            } while (op != 0);
                    Console.ReadKey();
            #endregion
        }
    }
}
    

