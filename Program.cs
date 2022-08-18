using interaction_bdd_crud.Models;

static ushort CreateArtist(disquaireContext ctx, string name, DateOnly birthday)
{
    Artist artistToCreate = new Artist() { Name = name, Birthday = birthday };
    ctx.Artists.Add(artistToCreate);
    ctx.SaveChanges();
    return artistToCreate.Id;
}

static void UpdateArtist(disquaireContext ctx, string name, DateOnly birthday, ushort id){
    Artist artistToUpdate = ctx.Artists.Find(id);
    artistToUpdate.Name = name;
    artistToUpdate.Birthday = birthday;
    ctx.SaveChanges();
}

static void DeleteArtist(disquaireContext ctx, ushort id) 
{
     Artist artistToRemove = ctx.Artists.Find(id);
    ctx.Artists.Remove(artistToRemove); 
    ctx.SaveChanges();
       
}











static void Main(string[] args)
{
    

}