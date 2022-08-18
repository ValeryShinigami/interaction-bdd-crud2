using interaction_bdd_crud.Models;

//Create method
static ushort CreateArtist(disquaireContext ctx, string name, DateOnly birthday)
{
    Artist artistToCreate = new Artist() { Name = name, Birthday = birthday };
    ctx.Artists.Add(artistToCreate);
    ctx.SaveChanges();
    return artistToCreate.Id;
}
//Update method
static void UpdateArtist(disquaireContext ctx, string name, DateOnly birthday, ushort id){
    Artist artistToUpdate = ctx.Artists.Find(id);
    artistToUpdate.Name = name;
    artistToUpdate.Birthday = birthday;
    ctx.SaveChanges();
}
//Delete method
static void DeleteArtist(disquaireContext ctx, ushort id) 
{
     Artist artistToRemove = ctx.Artists.Find(id);
    ctx.Artists.Remove(artistToRemove); 
    ctx.SaveChanges();
       
}


static void Main(string[] args)
{
    ushort idArtist = CreateArtist(ctx, "kobe", 1982/01/01);
    UpdateArtist(ctx,"lebron", 1982/01/01);
    DeleteArtist(ctx, idArtist);


//requêtes sur des objets enumerable
   using (disquaireContext ctx = new disquaireContext()) 
    {
        //afficher en console la list des artistes qui commencent par v
         List<Artist> artists = ctx.Artists.Where(a=>a.Name.StartsWith("v")).ToList();

        foreach (Artist item in artists)
	    {
            Console.WriteLine("le nom est: " + item);
	    }
    }

    

}