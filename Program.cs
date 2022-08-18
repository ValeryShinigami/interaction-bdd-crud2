using interaction_bdd_crud.Models;

static ushort CreateArtist(disquaireContext ctx, string name, DateOnly birthday)
{
    Artist artistToCreate = new Artist() { Name = name, Birthday = birthday };
    ctx.Artists.Add(artistToCreate);
    ctx.SaveChanges();
    return artistToCreate.Id;
}











static void Main(string[] args)
{
    

}