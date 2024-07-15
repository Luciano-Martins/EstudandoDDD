namespace AcademiaAppication.Info
{
    public class Information
    {
        /*
         
        Estamos desenvolvendo um sistema para controle de academias, esse sistemas vai ser desenvolvido no designer DDD.
        O primeior passo foi criar uma solução vazia , onde adicionamos 4 pastas , estas pastas cada uma ganha um nome, 
        são eles : 1.Application, 2.Domain, 3.Repositories,4.Infra

        em cada pasta é criado seu referente projeto

        Appication , foi criado um projeto mvc, para ser a aplicação com as views etc...
        Domain , Essa vai abrigar as models de propriedades / nesse criamos uma biblioteca de classes
        Repositories , serão colocados todos os repositorios 
        Infra , onde vamos colocar toda conexão com o banco


        criamos uma classe chamada Users como exemplo, foi criada a tabela User, com todos os valores do campos criados pelo 
        padão do entityFramework , ou seja todos os valores max, agora vas alterar esse valor atraves do mesmo,

        aplicamos a Tecnica chamada fluente  Api , que seria , neste projeto , criei o banco e uma tabela , não especifiquei os tipos de campos
        nem seus valos o entityframework os crior com padrões, essa tecnica vou alterar esses valores,  criei uma pasta no projeto Infra com
        o nome de DataConfig e dentro dela criei uma classe e atribui o nome de UsersConfiguration já que vou alterar a tabela Users,  a classe
        Herda da classe  IEntityTypeConfiguration<Users> e passei minha tabela para ela , no caso Users, criei um metodo chamado Configure
        esse método vai alterar os valores dos tipos de campos , esse metodo será acessado do meu dbContext lá invocarei o metodo dentro do 
        OnModelCreating. na verdade fazemos isso dentro do DbContext no metodo OnModelCreating, essa tecnica deixa mais organizado.


        Agora vamos começar a criar o Identity
        
         
         
         
         
         
         
         
         
         
         */
    }
}
