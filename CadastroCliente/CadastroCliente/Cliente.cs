class Cliente() { 
    public string nome { get; set; }
    public string email { get; set; }
    public string cpf_cnpj { get; set; }


    public void ExibirInfo()
    {
        Console.WriteLine($"Nome: {nome} | Email: {email} | CPF: {cpf_cnpj}");
    }

    public void ExibirClientes()
    {

        ExibirInfo();
        Console.WriteLine("--------------------------------");
    }

}