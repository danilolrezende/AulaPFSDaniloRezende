using System;
using AtletaApi.Dtos;
using AtletaApi.Infra;
using AtletaApi.Models;
using Aula10;
using Microsoft.EntityFrameworkCore;

namespace AtletaApi.EndPoints;

public static class AtletaEndPoints
{

    public static void AdicionarAtletaEndPoints(this WebApplication app)
    {
        var grupo = app.MapGroup("/atletas");
        grupo.MapGet("/", GetAsync);
        grupo.MapGet("/{id}", GetByIdAsync);
        grupo.MapPost("", PostAsync);
        grupo.MapPut("/{id}", PutAsync);
        grupo.MapDelete("/{id}", DeleteAsync);
    }

    private static async Task<IResult> GetAsync(AtletaContext db)
    {
        var objetos = await db.Atletas.ToListAsync();
        return TypedResults.Ok(objetos.Select(x => new AtletaDTO(x)));
    }

    private static async Task<IResult> GetByIdAsync(string id, AtletaContext db)
    {
        var obj = await db.Atletas.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(new AtletaDTO(obj));
    }



    private static async Task<IResult> PostAsync(AtletaDTO dto, AtletaContext db)
    {
        Atleta obj = dto.GetModel();
        obj.Id = GeradorId.GetId();
        await db.Atletas.AddAsync(obj);
        await db.SaveChangesAsync();

        return TypedResults.Created($"atletas/{obj.Id}", new AtletaDTO(obj));
    }

    private static async Task<IResult> PutAsync(string id, AtletaDTO dto, AtletaContext db)
    {
        if (id != dto.Id)
        {
            return TypedResults.BadRequest();
        }

        var obj = await db.Atletas.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        dto.preencherModel(obj);

        db.Atletas.Update(obj);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    private static async Task<IResult> DeleteAsync(string id, AtletaContext db)
    {
        var obj = await db.Atletas.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        db.Atletas.Remove(obj);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

}
