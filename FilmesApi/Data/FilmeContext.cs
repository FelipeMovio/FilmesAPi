using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{

    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Sessao é uma entidade associativa entre Filme e Cinema (relação N:N modelada explicitamente).
        // Usa chave composta (FilmeId + CinemaId): garante que não existam duas sessões
        // para o mesmo filme no mesmo cinema. Se essa regra mudar (ex: permitir múltiplos
        // horários do mesmo filme no mesmo cinema), essa modelagem precisa mudar também
        // (chave substituta + campo de horário na chave, por exemplo).
        builder.Entity<Sessao>()
            .HasKey(sessao => new
            {
                sessao.FilmeId,
                sessao.CinemaId
            });
        // Um Cinema pode ter várias Sessoes (1:N), FK = CinemaId
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);
        // Um Filme pode ter várias Sessoes (1:N), FK = FilmeId  
        builder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Cinema)
            .WithOne(cinema => cinema.Endereco)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}
