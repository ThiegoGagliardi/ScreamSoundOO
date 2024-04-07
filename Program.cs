
using System.Reflection.Metadata;
using System.Text;
using ScreamSoundOO.src.model;
using ScreamSoundOO.src.db;
using ScreamSoundOO.src.Interfaces;
using ScreamSoundOO.src.utils;
using ScreamSoundOO.src.DTO;
using ScreamSoundOO.src.services;

void ExibirLogo()
{

    Console.Clear();
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");

    string mensagemBoasVindas = "Bem vindos ao Scream Sound";

    Console.WriteLine("");
    Console.WriteLine(mensagemBoasVindas);
    Console.WriteLine("");
}

void MenuLogin()
{    
    ExibirTitulo("Login");

    Console.WriteLine("Digite -1 para sair");
    Console.WriteLine("Digite 1 para fazer o login");
    Console.WriteLine("Digite 2 para fazer o cadastro");
}

void ExibirMenu()
{
    Console.WriteLine("Digite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de uma banda.");
    Console.WriteLine("Digite 5 para exibir todas as notas de uma banda.");
    Console.WriteLine("Digite 6 buscar banda por genero.");
    Console.WriteLine("Digite 7 Mostrar bandas avaliadas pelo usuário.");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
}

void AguardarTecla()
{
    Console.WriteLine();
    Console.WriteLine("Digite qualque tecla para voltar ao menu principal.");
    Console.ReadKey();
}

void VoltarParaMenuPrincipal()
{
    Console.Clear();

    ExibirLogo();
    ExibirMenu();
}

bool LocalizarBanda(string nome, out Banda banda)
{
    BandaService bandaService = new BandaService();
    banda = bandaService.BuscarBandaPorNomeAsync(nome).Result;

    if (banda is null){     
        return false;
    }    

    return true;
}

void MostrarBandas()
{

    ExibirTitulo("Exibir Bandas");

    BandaService bandaService = new BandaService();

    var bandas = bandaService.BuscarTodasBandasAsync().Result;

    foreach (var banda in bandas)
    {
        Console.WriteLine($"Banda: {banda.Nome}");
    }

    AguardarTecla();

    VoltarParaMenuPrincipal();
}

void MostrarBandasGenero()
{

    ExibirTitulo("Exibir Bandas Por Genero");

    BandaService bandaService = new BandaService();

    Console.Write("Digitar o genero que deseja buscar:");
    Genero genero = (Genero) Enum.Parse(typeof(Genero), Console.ReadLine()!);

    var bandas = bandaService.BuscarBandaGeneroAsync(genero).Result;

    foreach (var banda in bandas)
    {
        Console.WriteLine($"Banda: {banda.Nome}");
    }

    AguardarTecla();

    VoltarParaMenuPrincipal();
}

void RegistrarBandas()
{
    BandaService bandaService = new BandaService();
    BandaDTO banda = new BandaDTO();

    Console.Clear();

    ExibirTitulo("Registro de Bandas");

    Banda bandaConsultada = null;

    Console.Write("Digite o nome da banda para regsitro: ");
    string nome = Console.ReadLine()!; 
    banda.Nome = nome;   

    if (LocalizarBanda(nome, out bandaConsultada)){

        Console.WriteLine("Banda já cadastrada.");
        Thread.Sleep(2000);
        VoltarParaMenuPrincipal();           
        return;
    }

    Console.Write($"Digite o genero da banda que deseja registrar: ");
    string generoBanda = Console.ReadLine()!;
    banda.Genero = (Genero)Enum.Parse(typeof(Genero), generoBanda);

    Console.Write($"Digite a data de fundacao da banda: ");
    DateTime fundacao = DateTime.Parse(Console.ReadLine()!);
    banda.Fundacao = fundacao;

    bandaService.InserirBandaAsync(banda);

    Console.WriteLine($"{banda.Nome} registrada com sucesso.");

    Thread.Sleep(2000);

    VoltarParaMenuPrincipal();
}

void EncerrarPrograma()
{

    Console.Write("Selecionado Sair. Bye! :-)");
    Thread.Sleep(2000);
    Console.Clear();
    Environment.Exit(0);
}

void AvaliarBanda(Usuario user)
{
    ExibirTitulo("Avaliar Banda");
    
    Banda banda = null;

    Console.Write("Digite o nome da banda para avaliação: ");
    string nome = Console.ReadLine()!;     

    if (!LocalizarBanda(nome, out banda)){
        Console.WriteLine("Banda não localizada.");
        Thread.Sleep(2000);
        VoltarParaMenuPrincipal();           
        return;
    }

    Console.Write("Digite a nota da banda:");
    int nota = int.Parse(Console.ReadLine()!);
    
    NotaDTO notaDto = new NotaDTO(user.Id, banda.Id, nota);

    NotaService notaService = new NotaService();

    if (notaService.InserirNotaAsync(notaDto).Result) {

        Console.Write("Banda avaliada com sucesso");
        Thread.Sleep(4000);
    }

    VoltarParaMenuPrincipal();
}

void ExibirTitulo(string titulo)
{

    int tamanhoTitulo = titulo.Length;
    StringBuilder sb = new StringBuilder("*", titulo.Length + 2);

    for (int i = 0; i < tamanhoTitulo + 2; i++)
    {
        sb.Insert(0, "*");
    }

    string label = sb.ToString();

    Console.WriteLine();
    Console.WriteLine(label);
    Console.WriteLine("  " + titulo);
    Console.WriteLine(label);
    Console.WriteLine();
}

void ExibirTodasNotasDeUmaBanda()
{

    ExibirTitulo("Mostrar notas de uma Banda");

    Banda banda = null;

    Console.Write("Digite o nome da banda para consultar notas: ");
    string nome = Console.ReadLine()!;     

    if (!LocalizarBanda(nome, out banda)){

        Console.WriteLine("Banda não localizada.");
        Thread.Sleep(2000);
        VoltarParaMenuPrincipal();
        return;        
    }


    NotaService notaService = new NotaService();

    var notas  = notaService.BuscarNotasBandaAsync(banda).Result;

    if (notas.Count == 0) {

        Console.WriteLine("Banda não avaliada.");
        Thread.Sleep(1000);

        AguardarTecla();

        VoltarParaMenuPrincipal();        
    }

    foreach(var n in notas){
        Console.WriteLine($"{n.NomeBanda}: {n.Nota}");
    }

    AguardarTecla();

    VoltarParaMenuPrincipal();
}

void ExibirMediaDeUmaBanda()
{

    ExibirTitulo("Mostrar Média da Banda");

    Banda banda = new Banda();

    Console.Write("Digite o nome da banda para veriticar a Média: ");
    string nome = Console.ReadLine()!;     

    if (!LocalizarBanda(nome, out banda)){

        Console.WriteLine("Banda não localizada");
        Thread.Sleep(2000);
        VoltarParaMenuPrincipal();           
        return;
    }

    NotaService notaService = new NotaService();

    var notas = notaService.BuscarNotasBandaAsync(banda).Result;

    int total = 0;
    notas.ForEach((nota) => { total += nota.Nota;});

    Console.WriteLine($"A média da banda {banda.Nome} é: {total/notas.Count} ");

    AguardarTecla();

    VoltarParaMenuPrincipal();
}

void ExibirBandasAvaliadasUsuario(Usuario user){

    ExibirTitulo("Bandas Avaliadas");

    NotaService notaService = new NotaService();

    var notas = notaService.BuscarNotasUsuarioBandaAsync(user).Result;

    if (notas.Count == 0){

        Console.WriteLine("Usuario não avaliou nenhuma banda.");
        Thread.Sleep(1000);

        AguardarTecla();

        VoltarParaMenuPrincipal();          

        return;
    }
    
    notas.ForEach((nota) => { Console.WriteLine($"{nota.NomeBanda}:{nota.Nota}");});   

    AguardarTecla();

    VoltarParaMenuPrincipal();    
}

Usuario FazerLogin()
{

    UserService userService = new UserService();

    UserDTO user = new UserDTO();

    Console.WriteLine("Digite o nome do usuário:");
    user.Nome = Console.ReadLine()!;

    Console.WriteLine("Digite o Senha do usuario:");
    user.Senha = Console.ReadLine()!;

    var usuario = userService.BuscarUsuarioAsync(user).Result;
    
    Console.Clear();
    if (!(usuario is null))
    {       
        Console.WriteLine("Login efetuado");       
    }else {        
        Console.WriteLine("Usuario/Senha incorretos");        
    }

    Thread.Sleep(2000);

    return usuario;
}

Usuario CadastraUsuario()
{

    UserService userService = new UserService();

    UserDTO user = new UserDTO();

    Console.WriteLine("Digite o nome do usuário:");
    user.Nome = Console.ReadLine()!;

    Console.WriteLine("Digite o Senha do usuario:");
    user.Senha = Console.ReadLine()!;

    userService.InserirUsuarioAsync(user);

    Console.WriteLine("Usuario Cadastrado");

    return userService.BuscarUsuarioAsync(user).Result;  
 
}

Usuario user = null;

while (user is null)
{
    int opcaoLogin = 0;
    while ((opcaoLogin != -1) & (user is null))
    {
        MenuLogin();
        int.TryParse(Console.ReadLine(), out opcaoLogin);
        switch (opcaoLogin)
        {
            case -1:
                EncerrarPrograma();
                break;
            case 1:
                user = FazerLogin();
                break;
            case 2:
                user = CadastraUsuario(); 
                break;
            default: Console.WriteLine($" A opção {opcaoLogin.ToString()} é inválida. Escolha novamente a opcao"); break;
        }

        Console.Clear();
    }
}

ExibirLogo();
ExibirMenu();

int opcao = 0;
while (opcao != -1)
{
    int.TryParse(Console.ReadLine(), out opcao);

    switch (opcao)
    {
        case -1:
            EncerrarPrograma();
            break;
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandas();
            break;
        case 3:
            AvaliarBanda(user);
            break;
        case 4:
            ExibirMediaDeUmaBanda();
            break;

        case 5:
            ExibirTodasNotasDeUmaBanda();
            break;

        case 6:
            MostrarBandasGenero();
            break; 

        case 7:
            ExibirBandasAvaliadasUsuario(user);
            break;                        
        default: 
          Console.WriteLine($" A opção {opcao.ToString()} é inválida. Escolha novamente a opcao"); 
          break;
    }
}
