using System;
using System.Threading;

string mensagem = "Bem-vindo ao sistema de cadastro de clientes!";
//Dictionary<string, List<int>> clientes = new Dictionary<string, List<int>>();
List<string> emails = new List<string> {};
List<string> clientes = new List<string> {};
List<string> cpfs = new List<string> {};



void exbirLogo()
{

    Console.WriteLine(@"
 $$$$$$\                  $$\                       $$\                                     $$\                  $$$$$$\  $$\ $$\                      $$\                         
$$  __$$\                 $$ |                      $$ |                                    $$ |                $$  __$$\ $$ |\__|                     $$ |                        
$$ /  \__| $$$$$$\   $$$$$$$ | $$$$$$\   $$$$$$$\ $$$$$$\    $$$$$$\   $$$$$$\         $$$$$$$ | $$$$$$\        $$ /  \__|$$ |$$\  $$$$$$\  $$$$$$$\ $$$$$$\    $$$$$$\   $$$$$$$\ 
$$ |       \____$$\ $$  __$$ | \____$$\ $$  _____|\_$$  _|  $$  __$$\ $$  __$$\       $$  __$$ |$$  __$$\       $$ |      $$ |$$ |$$  __$$\ $$  __$$\\_$$  _|  $$  __$$\ $$  _____|
$$ |       $$$$$$$ |$$ /  $$ | $$$$$$$ |\$$$$$$\    $$ |    $$ |  \__|$$ /  $$ |      $$ /  $$ |$$$$$$$$ |      $$ |      $$ |$$ |$$$$$$$$ |$$ |  $$ | $$ |    $$$$$$$$ |\$$$$$$\  
$$ |  $$\ $$  __$$ |$$ |  $$ |$$  __$$ | \____$$\   $$ |$$\ $$ |      $$ |  $$ |      $$ |  $$ |$$   ____|      $$ |  $$\ $$ |$$ |$$   ____|$$ |  $$ | $$ |$$\ $$   ____| \____$$\ 
\$$$$$$  |\$$$$$$$ |\$$$$$$$ |\$$$$$$$ |$$$$$$$  |  \$$$$  |$$ |      \$$$$$$  |      \$$$$$$$ |\$$$$$$$\       \$$$$$$  |$$ |$$ |\$$$$$$$\ $$ |  $$ | \$$$$  |\$$$$$$$\ $$$$$$$  |
 \______/  \_______| \_______| \_______|\_______/    \____/ \__|       \______/        \_______| \_______|       \______/ \__|\__| \_______|\__|  \__|  \____/  \_______|\_______/ 
");
    Console.WriteLine(mensagem);
}

void exibirMenu()
{
    exbirLogo();

    Console.WriteLine("\nSelecione uma opção:");
    Console.WriteLine("1. Cadastrar cliente");
    Console.WriteLine("2. Listar clientes");
    Console.WriteLine("3. Buscar Clientes por CPF");
    Console.WriteLine("4. Remover os clientes da Lista");
    Console.WriteLine("5. Sair");


    Console.WriteLine("\nInforme a Opção desejada");

    int opcoes = int.Parse(Console.ReadLine());

    switch (opcoes)
    {

        case 1:
            cadastroCliente();
            break;
        case 2:
            exibirListarClientes();
            break;
        case 3:
            buscarCliCpf();
            break;
        case 4:
            removerClientes();
            break;
        case 5:
            Console.WriteLine("Tecleque 5 para sair");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }

}

void cadastroCliente()
{
    ExibirTituloDaOpcao("Cadastro de Cliente");

    var opcao = "1";

    while (opcao == "1")
    {
        Console.WriteLine("Informe o nome do cliente:");
        string nome = Console.ReadLine();
        clientes.Add(nome);
        Console.WriteLine("Informe o CPF:");
        string cpf = Console.ReadLine();

        if (cpf.Length != 11)
        {
            Console.WriteLine("CPF inválido. Deve conter 11 dígitos.");
            Console.WriteLine("Você retornará ao menu");
            Thread.Sleep(1000);
            exibirMenu();
        }

        if (cpfs.Contains(cpf))
        {
            Console.WriteLine("CPF já cadastrado.");
            Thread.Sleep(1500);
            exibirMenu();
        }
        cpfs.Add(cpf);


        Console.WriteLine("Informe o email do cliente:");
        string email = Console.ReadLine();
        emails.Add(email);

        Console.WriteLine($"Cliente {nome} com email {email} cadastrado com sucesso!\n");
        Console.WriteLine("Deseja cadastrar outro cliente? (1 - Sim / 2 - Não)");



        opcao = Console.ReadLine();
        Console.Clear();
    }


    Thread.Sleep(1000);
    exibirMenu();


}
void exibirListarClientes()
{
    Console.Clear();
    ExibirTituloDaOpcao("Listar Clientes");

    for (int i = 0; i < clientes.Count; i++)
    {
        Console.WriteLine(
            $"Nome: {clientes[i]} | Email: {emails[i]} | CPF: {cpfs[i]}"
        );
        Console.WriteLine("--------------------------------");
    }

    Console.WriteLine("\nAperte qualquer tecla para voltar");
    Console.ReadKey();
    exibirMenu();
}

void buscarCliCpf()
{
    ExibirTituloDaOpcao("Buscar Cliente por CPF");
    // Lógica para buscar cliente por CPF
    Console.Clear();

    Console.WriteLine("Informe o CPF do cliente que deseja buscar:");
    string cpfBusca = Console.ReadLine();
    int index = cpfs.IndexOf(cpfBusca);

    if (index != -1)
    {
        Console.WriteLine($"Cliente encontrado: {clientes[index]}, Email: {emails[index]}, CPF: {clientes[index]}");
    }
    else
    {
        Console.WriteLine("Cliente não encontrado.");
    }

    Console.WriteLine("\nAperte a tecla X para sair");
    Console.ReadKey();
    exibirMenu();

}
void removerClientes()
{
    ExibirTituloDaOpcao("Remover Cliente cadastrado");
    Console.Clear();

    Console.WriteLine("Informe o CPF do cliente que deseja remover:");
    string cpfRemover = Console.ReadLine();
    int index = cpfs.IndexOf(cpfRemover);

    if (index != -1)
    {
        Console.WriteLine($"Cliente {clientes[index]} removido com sucesso.");
        clientes.RemoveAt(index);
        cpfs.RemoveAt(index);
        emails.RemoveAt(index);
    }
    else
    {
        Console.WriteLine("Cliente não encontrado.");
    }

}

// Opção de editar mensagem nos menus selecionado (Opcional)

void ExibirTituloDaOpcao(string titulo)
{
    // Colocar o asteriscos do tamanho da frase
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}



exibirMenu();