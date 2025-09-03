using JcmSoft.Domain.Entities;
using JcmSoft.EFCore.Context;

using (AppDbContext context = new AppDbContext())
{
    context.Database.EnsureDeleted();
    Console.WriteLine("Criando o banco de dados...\n");
    context.Database.EnsureCreated();
    Console.WriteLine("Operação realizada com sucesso...\n");

    //Console.WriteLine("Incluindo funcionário(s)...\n");
    //IncluirFuncionarioAdd(context);

    //Console.WriteLine("Incluindo departamento e funcionário...\n");
    //IncluirFuncionarioAddRelacional(context);

    //Console.WriteLine("Criando um departamento...\n");
    //CriarDepartamento(context);
    //Console.WriteLine("Departamento criado...\n");

    // Retorna todos os departamentos usando o ToList 
    //Console.WriteLine("Listando os departamentos:");
    //ListarDepartamentos(context);

    //Console.WriteLine("\nBuscando um departamento por Id == 3");
    //BuscaDeptoPorId(context, 3);
}
Console.ReadKey();

/*
void CriarDepartamento(AppDbContext context)
{
    
    var departamento = new Departamento
    {
        Nome = "Desenvolvimento",
        Descricao = "Desenvolvimento de projetos"
    };
    var departamento1 = new Departamento
    {
        Nome = "Marketing",
        Descricao = "Promoção e Vendas"
    };
    var departamento2 = new Departamento
    {
        Nome = "Recursos Humanos",
        Descricao = "Gestão de Pessoas"
    };
    var departamento3 = new Departamento
    {
        Nome = "Suporte",
        Descricao = "Suporte e Serviços"
    };
    context.Departamentos.Add(departamento);
    context.Departamentos.Add(departamento1);
    context.Departamentos.Add(departamento2);
    context.Departamentos.Add(departamento3);  

    var departamentos = new List<Departamento>
    {
        new Departamento { Nome = "Desenvolvimento", Descricao = "Desenvolvimento de projetos" },
        new Departamento { Nome = "Financeiro", Descricao = "Gestão de Finanças" },
        new Departamento { Nome = "Marketing", Descricao = "Promoção e Vendas" },
        new Departamento { Nome = "Recursos Humanos", Descricao = "Gestão de Pessoas" },
        new Departamento { Nome = "Suporte", Descricao = "Suporte e Serviços" }
    }; 

    foreach (var item in departamentos)
    {
        context.Departamentos.Add(new Departamento
        {
            Nome = item.Nome,
            Descricao = item.Descricao
        });
    }
    
    context.SaveChanges(); 
}


void ListarDepartamentos(AppDbContext context)
{
    var departamentos = context.Departamentos.ToList();
    foreach (var depto in departamentos)
    {
        Console.WriteLine($"Id: {depto.DepartamentoId} - Nome: {depto.Nome}");
    }
}

void BuscaDeptoPorId(AppDbContext context, int id)
{
    var depto = context.Departamentos.FirstOrDefault(d => d.DepartamentoId == id);
    Console.WriteLine(depto != null 
        ? $"Id: {depto.DepartamentoId} - Nome: {depto.Nome}"
        : "Departamento não encontrado.");
}

*/

/*
static void IncluirFuncionarioAdd(AppDbContext context)
{
    var funcionarios = new List<Funcionario>
    {
        new Funcionario {
            Nome = "Kelvin Gustavo",
            Cargo = "Analista de Finanças",
            Salario = 5000.00M,
            DataContratacao = new DateOnly(2023, 1, 15),
            DepartamentoId = 2
        },
        new Funcionario {
            Nome = "Sara Katherine",
            Cargo = "Coordenadora de Marketing",
            Salario = 5000.00M,
            DataContratacao = new DateOnly(2023, 1, 15),
            DepartamentoId = 3
        },
        new Funcionario {
            Nome = "Rita Wilemem",
            Cargo = "Analista de RH",
            Salario = 6000.00M,
            DataContratacao = new DateOnly(2023, 1, 15),
            DepartamentoId = 4
        }
    };

    foreach (var funcionario in funcionarios)
    {
        context.Funcionarios.Add(new Funcionario
        {
            Nome = funcionario.Nome,
            Cargo = funcionario.Cargo,
            Salario = funcionario.Salario,
            DataContratacao = funcionario.DataContratacao,
            DepartamentoId = funcionario.DepartamentoId
        });
    }
    
    context.SaveChanges();
}

static void IncluirFuncionarioAddRelacional(AppDbContext context)
{
    var departamento = new Departamento
    {
        Nome = "TI",
        Descricao = "Tecnologia da Informação"
    };

    // Adicionando Funcionário ao Departamento
    departamento.Funcionarios.Add(
        new Funcionario {
            Nome = "Alexander Alves",
            Cargo = "Programador Senior",
            Salario = 7000.00M,
            DataContratacao = new DateOnly(2023, 1, 15)
        });

    // Adiciona o departamento junto com os funcionários
    context.Departamentos.Add(departamento);
    context.SaveChanges();
}
*/

/*
static void IncluirFuncionarioEDetalhe(AppDbContext context)
{
    var detalheFuncionario1 = new FuncionarioDetalhe
    {
        EnderecoResidencial = "Rua A, 123",
        DataNascimento = new DateTime(1990, 1, 1),
        Celular = "1111-1111",
        Genero = Genero.Masculino,
        Foto = "foto1.jpg",
        EstadoCivil = EstadoCivil.Solteiro,
        CPF = "123.456.789-00",
        Nacionalidade = "Brasileira",
        Escolaridade = Escolaridade.Superior
    };
    var funcionario1 = new Funcionario
    {
        Nome = "José Silveira",
        Cargo = "Desenvolvedor",
        Salario = 5250m,
        DataContratacao = new DateOnly(2023, 7, 1),
        DepartamentoId = 1,
        FuncionarioDetalhe = detalheFuncionario1
    };

    context.Funcionarios.Add(funcionario1);
    context.SaveChanges();
} 
*/ 





