using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaApi.Dtos;
using AtletaApi.Infra;
using AtletaApi.Models;
using Aula10;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


public static class UsuarioEndPoints
{    

    public static void AdicionarUsuarioEndPoints(this WebApplication app)
    {
        var grupo = app.MapGroup("/usuarios");
        grupo.MapGet("/", GetAsync);
        grupo.MapGet("/{id}", GetByIdAsync);
        grupo.MapPost("", PostAsync);
        grupo.MapPost("/admin", PostAdminAsync);
        grupo.MapPut("/{id}", PutAsync);
        grupo.MapPatch("/{id}/{senhaAnterior}/{senhaNova}", PatchAlteraSenhaAsync);
        grupo.MapDelete("/{id}", DeleteAsync);
    }

    private static async Task<IResult> PatchAlteraSenhaAsync(string id, string senhaAnterior, string senhaNova, AtletaContext db, IPasswordHasher<Usuario> hasher)
    {
        var obj = await db.Usuarios.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        if(string.IsNullOrEmpty(obj.HashSenha) || 
        hasher.VerifyHashedPassword(obj, obj.HashSenha, senhaAnterior) != PasswordVerificationResult.Failed)
        {
            obj.HashSenha = hasher.HashPassword(obj, senhaNova);
        } 
        else 
        {
            return TypedResults.Unauthorized();
        }

        db.Usuarios.Update(obj);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }


    private static async Task<IResult> GetAsync(AtletaContext db)
    {
        var objetos = await db.Usuarios.ToListAsync();
        return TypedResults.Ok(objetos.Select(x => new UsuarioDTO(x)));
    }

    private static async Task<IResult> GetByIdAsync(string id, AtletaContext db)
    {
        var obj = await db.Usuarios.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }
        return TypedResults.Ok(new UsuarioDTO(obj));
    }



    private static async Task<IResult> PostAsync(UsuarioDTO dto, AtletaContext db)
    {
        Usuario obj = dto.GetModel();
        obj.Id = GeradorId.GetId();
        obj.Role = "comum";
        await db.Usuarios.AddAsync(obj);
        await db.SaveChangesAsync();

        return TypedResults.Created($"usuarios/{obj.Id}", new UsuarioDTO(obj));
    }

        private static async Task<IResult> PostAdminAsync(UsuarioDTO dto, AtletaContext db)
    {
        Usuario obj = dto.GetModel();
        obj.Id = GeradorId.GetId();
        obj.Role = "admin";
        await db.Usuarios.AddAsync(obj);
        await db.SaveChangesAsync();

        return TypedResults.Created($"usuarios/{obj.Id}", new UsuarioDTO(obj));
    }

    private static async Task<IResult> PutAsync(string id, UsuarioDTO dto, AtletaContext db)
    {
        if (id != dto.Id)
        {
            return TypedResults.BadRequest();
        }

        var obj = await db.Usuarios.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        dto.preencherModel(obj);

        db.Usuarios.Update(obj);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }

    private static async Task<IResult> DeleteAsync(string id, AtletaContext db)
    {
        var obj = await db.Usuarios.FindAsync(Convert.ToInt64(id));

        if (obj == null)
        {
            return TypedResults.NotFound();
        }

        db.Usuarios.Remove(obj);
        await db.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}
