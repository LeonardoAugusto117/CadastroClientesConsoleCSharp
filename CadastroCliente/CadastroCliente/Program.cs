using System;
using System.Reflection;
using System.Threading;

string mensagem = "Bem-vindo ao sistema de cadastro de clientes!";
//Dictionary<string, List<int>> clientes = new Dictionary<string, List<int>>();
//List<string> Emails = new List<string> {};
//List<string> clientes = new List<string> {};
//List<string> cpfs = new List<string> {};

List<Cliente> listaClientes = new List<Cliente>();

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

    // Loop para cadastrar múltiplos clientes
    while (opcao == "1")
    {
        Cliente clientes = new Cliente();

        Console.WriteLine("Informe o Nome do cliente:");
        clientes.Nome = Console.ReadLine();

        Console.WriteLine("Informe o CPF/CPNJ:");
        clientes.Cpf_cnpj = Console.ReadLine();

        if (clientes.Cpf_cnpj.Length != 11 && clientes.Cpf_cnpj.Length != 14)
        {
            Console.WriteLine("CPF inválido. Deve conter 11 números.");
            Console.ReadKey();
            Console.Clear();
            continue;
        }

        Console.WriteLine("Informe o Email do cliente:");
        clientes.Email = Console.ReadLine();

        Console.WriteLine($"Cliente {clientes.Nome} com Email {clientes.Email} e o CPF: {clientes.Cpf_cnpj} cadastrado com sucesso!\n");
        Console.WriteLine("Deseja cadastrar outro cliente? (1 - Sim / 2 - Não)");

        // Adiciona o cliente à lista
        listaClientes.Add(clientes);

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

    if (listaClientes.Count == 0){
        Console.WriteLine("Nenhum cliente cadastrado.");
    }
    else
    {
        foreach (Cliente cliente in listaClientes)
        {
            cliente.ExibirClientes();
        }
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
    String cpfBusca = Console.ReadLine();

    Cliente clienteEncontrado = null;

    // Procurar o cliente na lista pelo CPF
    foreach (Cliente cliente in listaClientes)
    {
        if (cliente.Cpf_cnpj == cpfBusca)
        {
            clienteEncontrado = cliente;
            break;
        }
    }

    // Exibir informações do cliente encontrado
    if (clienteEncontrado != null)
    {
        Console.WriteLine("\nCliente encontrado:");
        clienteEncontrado.ExibirInfo();
    }
    else
    {
        Console.WriteLine("\nCliente não encontrado.");
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

    Cliente clienteEncontrado = null;

    // Procurar o cliente na lista pelo CPF
    foreach (Cliente cliente in listaClientes)
    {
        if (cliente.Cpf_cnpj == cpfRemover)
        {
            clienteEncontrado = cliente;
            break;
        }
    }

    // Remover o cliente se encontrado
    if (clienteEncontrado != null)
    {
        listaClientes.Remove(clienteEncontrado);
        Console.WriteLine($"\nCliente: {clienteEncontrado.Nome} removido com sucesso!");
    }

    else
    {
        Console.WriteLine("\nCliente não encontrado.");
    }

    Console.WriteLine("\nAperte a tecla X para sair");
    Console.ReadKey();
    exibirMenu();

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
