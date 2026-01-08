class Clientes() { 
    public string nome { get; set; }
    public string email { get; set; }
    public string cpf { get; set; }


    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {nome} | Email: {email} | CPF: {cpf}");
    }

    public void ExibirClientes()
    {

        ExibirInfo();
        Console.WriteLine("--------------------------------");
    }

}