using Aula10;

var db = new AtletaContext();

//Adicionar(new Atleta{Id = 1, Nome = "Ana", Altura = 1.6, Peso = 55});
//Adicionar(new Atleta{Id = 2, Nome = "Bruno", Altura = 1.8, Peso = 80});

var a1 = retornarPorId(1);
var a2 = retornarPorId(2);

Console.WriteLine($"Nome: {a1?.Nome}, Altura: {a1?.Altura}, Peso: {a1?.Peso}");

Console.WriteLine($"Nome: {a2?.Nome}, Altura: {a2?.Altura}, Peso: {a2?.Peso}");

if (a1!= null)
{
    a1 += " Maria";
    Atualizar(a1);
}

void Atualizar(Atleta obj)
{
    db.Atletas.Update(obj);
    db.SaveChanges();
}


Console.WriteLine($"Nome: {a1?.Nome}, Altura: {a1?.Altura}, Peso: {a1?.Peso}");

Console.WriteLine($"Nome: {a2?.Nome}, Altura: {a2?.Altura}, Peso: {a2?.Peso}");

Atleta? retornarPorId(long id)
{
    return db.Atletas.Find(id);
}

void Adicionar(Atleta obj)
{
    db.Atletas.Add(obj);
    db.SaveChanges();
}



db.Atletas.remove(a1);
db.SaveChanges();

var Aletas = db.Aletas.ToList();