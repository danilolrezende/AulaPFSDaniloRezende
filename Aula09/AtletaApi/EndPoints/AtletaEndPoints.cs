using System;
using AtletaApi.Infra;
using AtletaApi.Models;
using Aula10;

namespace AtletaApi.EndPoints;

public static class AtletaEndPoints
{

    public static void AdicionarAtletaEndPoints(this WebApplication app)
    {
        var grupo = app.MapGroup("/atletas");
        grupo.MapGet("/", Get);
        grupo.MapGet("/{id}", GetById);
        grupo.MapPost("", Post);
        grupo.MapPut("/{id}",Put);
        grupo.MapDelete("/{id}", Delete);
    }

    private static IResult GetById(long id, AtletaContext db)
    {
        var obj = db.Atletas.Find(id);

        if (obj == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(obj);
    }

    private static IResult Get(AtletaContext db)
    {        
        return TypedResults.Ok(db.Atletas.ToList());
    }

    private static IResult Post(Atleta obj, AtletaContext db)
    {
        obj.Id = GeradorId.GetId();
        db.Atletas.Add(obj);
        db.SaveChanges();

        return TypedResults.Created($"atletas/{obj.Id}", obj);
    }

    private static IResult Put(long id, Atleta objNovo, AtletaContext db)
    {
        if (id != objNovo.Id)
        {
            return TypedResults.BadRequest();
        }

        var obj = db.Atletas.Find(id);

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        obj.Nome = objNovo.Nome;
        obj.Altura = objNovo.Altura;
        obj.Peso = objNovo.Peso;

        db.Atletas.Update(obj);
        db.SaveChanges();

        return TypedResults.NoContent();
    }

    private static IResult Delete(long id, AtletaContext db)
    {
        var obj = db.Atletas.Find(id);

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        db.Atletas.Remove(obj);
        db.SaveChanges();   

        return TypedResults.NoContent();
    }

}
