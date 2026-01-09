class Cliente() { 
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
    public string Cpf_cnpj { get; set; } = "";


    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {Nome} | Email: {Email} | CPF: {Cpf_cnpj}");
    }

    public void ExibirClientes()
    {
        ExibirInfo();
        Console.WriteLine("--------------------------------");
    }

}