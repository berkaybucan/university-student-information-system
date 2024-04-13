using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ObsWepApp.Models;

public partial class ObsContext : DbContext
{
    public ObsContext()
    {
    }

    public ObsContext(DbContextOptions<ObsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AkademikDonem> AkademikDonems { get; set; }

    public virtual DbSet<AkademikYil> AkademikYils { get; set; }

    public virtual DbSet<Bolum> Bolums { get; set; }

    public virtual DbSet<Cinsiyet> Cinsiyets { get; set; }

    public virtual DbSet<Danismanlik> Danismanliks { get; set; }

    public virtual DbSet<Degerlendirme> Degerlendirmes { get; set; }

    public virtual DbSet<DersAcma> DersAcmas { get; set; }

    public virtual DbSet<DersAlma> DersAlmas { get; set; }

    public virtual DbSet<DersGunu> DersGunus { get; set; }

    public virtual DbSet<DersHavuzu> DersHavuzus { get; set; }

    public virtual DbSet<DersProgrami> DersProgramis { get; set; }

    public virtual DbSet<DersSaati> DersSaatis { get; set; }

    public virtual DbSet<DersSeviyesi> DersSeviyesis { get; set; }

    public virtual DbSet<DersTuru> DersTurus { get; set; }

    public virtual DbSet<Derslik> Dersliks { get; set; }

    public virtual DbSet<DerslikTuru> DerslikTurus { get; set; }

    public virtual DbSet<Durum> Durums { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<KullaniciTur> KullaniciTurs { get; set; }

    public virtual DbSet<Mufredat> Mufredats { get; set; }

    public virtual DbSet<Ogrenci> Ogrencis { get; set; }

    public virtual DbSet<OgrenimDili> OgrenimDilis { get; set; }

    public virtual DbSet<OgretimElemani> OgretimElemanis { get; set; }

    public virtual DbSet<OgretimTuru> OgretimTurus { get; set; }

    public virtual DbSet<ProgramTuru> ProgramTurus { get; set; }

    public virtual DbSet<SecilmeDurumu> SecilmeDurumus { get; set; }

    public virtual DbSet<Sinav> Sinavs { get; set; }

    public virtual DbSet<SinavTuru> SinavTurus { get; set; }

    public virtual DbSet<Unvan> Unvans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2C6E5LJ\\MSSQLSERVER01;Database=Obs;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AkademikDonem>(entity =>
        {
            entity.ToTable("AkademikDonem");

            entity.Property(e => e.AkademikDonemId)
                .ValueGeneratedNever()
                .HasColumnName("AkademikDonemID");
            entity.Property(e => e.AkademikDonemi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AkademikYil>(entity =>
        {
            entity.ToTable("AkademikYil");

            entity.Property(e => e.AkademikYilId)
                .ValueGeneratedNever()
                .HasColumnName("AkademikYilID");
            entity.Property(e => e.AkademikYili)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Bolum>(entity =>
        {
            entity.ToTable("Bolum");

            entity.Property(e => e.BolumId)
                .ValueGeneratedNever()
                .HasColumnName("BolumID");
            entity.Property(e => e.BolumAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OgrenimDiliId).HasColumnName("OgrenimDiliID");
            entity.Property(e => e.OgretimTuruId).HasColumnName("OgretimTuruID");
            entity.Property(e => e.ProgramTuruId).HasColumnName("ProgramTuruID");
            entity.Property(e => e.WebAdresi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cinsiyet>(entity =>
        {
            entity.ToTable("Cinsiyet");

            entity.Property(e => e.CinsiyetId)
                .ValueGeneratedNever()
                .HasColumnName("CinsiyetID");
            entity.Property(e => e.Cinsiyeti)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Danismanlik>(entity =>
        {
            entity.ToTable("Danismanlik");

            entity.Property(e => e.DanismanlikId)
                .ValueGeneratedNever()
                .HasColumnName("DanismanlikID");
            entity.Property(e => e.OgrElmId).HasColumnName("OgrElmID");
            entity.Property(e => e.OgrenciId).HasColumnName("OgrenciID");
        });

        modelBuilder.Entity<Degerlendirme>(entity =>
        {
            entity.ToTable("Degerlendirme");

            entity.Property(e => e.DegerlendirmeId).ValueGeneratedNever();
            entity.Property(e => e.OgrenciId).HasColumnName("OgrenciID");
            entity.Property(e => e.SinavId).HasColumnName("SinavID");
        });

        modelBuilder.Entity<DersAcma>(entity =>
        {
            entity.ToTable("DersAcma");

            entity.Property(e => e.DersAcmaId)
                .ValueGeneratedNever()
                .HasColumnName("DersAcmaID");
            entity.Property(e => e.AkademikDonemId).HasColumnName("AkademikDonemID");
            entity.Property(e => e.AkademikYilId).HasColumnName("AkademikYilID");
            entity.Property(e => e.MufredatId).HasColumnName("MufredatID");
            entity.Property(e => e.OgrElmId).HasColumnName("OgrElmID");
        });

        modelBuilder.Entity<DersAlma>(entity =>
        {
            entity.ToTable("DersAlma");

            entity.Property(e => e.DersAlmaId)
                .ValueGeneratedNever()
                .HasColumnName("DersAlmaID");
            entity.Property(e => e.DersAcmaId).HasColumnName("DersAcmaID");
            entity.Property(e => e.OgrenciId).HasColumnName("OgrenciID");
            entity.Property(e => e.SecilmeDurumuId).HasColumnName("SecilmeDurumuID");
        });

        modelBuilder.Entity<DersGunu>(entity =>
        {
            entity.ToTable("DersGunu");

            entity.Property(e => e.DersGunuId)
                .ValueGeneratedNever()
                .HasColumnName("DersGunuID");
            entity.Property(e => e.DersGunuAdi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DersHavuzu>(entity =>
        {
            entity.HasKey(e => e.DersId);

            entity.ToTable("DersHavuzu");

            entity.Property(e => e.DersId)
                .ValueGeneratedNever()
                .HasColumnName("DersID");
            entity.Property(e => e.DersAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DersKodu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DersSeviyesiId).HasColumnName("DersSeviyesiID");
            entity.Property(e => e.DersTuruId).HasColumnName("DersTuruID");
            entity.Property(e => e.Ects).HasColumnName("ECTS");
            entity.Property(e => e.OgrenimDiliId).HasColumnName("OgrenimDiliID");
        });

        modelBuilder.Entity<DersProgrami>(entity =>
        {
            entity.HasKey(e => e.DersPrgId);

            entity.ToTable("DersProgrami");

            entity.Property(e => e.DersPrgId)
                .ValueGeneratedNever()
                .HasColumnName("DersPrgID");
            entity.Property(e => e.DersAcmaId).HasColumnName("DersAcmaID");
            entity.Property(e => e.DersGunuId).HasColumnName("DersGunuID");
            entity.Property(e => e.DersSaatiId).HasColumnName("DersSaatiID");
            entity.Property(e => e.DerslikId).HasColumnName("DerslikID");
        });

        modelBuilder.Entity<DersSaati>(entity =>
        {
            entity.ToTable("DersSaati");

            entity.Property(e => e.DersSaatiId).HasColumnName("DersSaatiID");
            entity.Property(e => e.DersSaatiSaat)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<DersSeviyesi>(entity =>
        {
            entity.ToTable("DersSeviyesi");

            entity.Property(e => e.DersSeviyesiId).HasColumnName("DersSeviyesiID");
            entity.Property(e => e.DersSeviyesiSeviye)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<DersTuru>(entity =>
        {
            entity.ToTable("DersTuru");

            entity.Property(e => e.DersTuruId).HasColumnName("DersTuruID");
            entity.Property(e => e.DersTuruTur)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Derslik>(entity =>
        {
            entity.ToTable("Derslik");

            entity.Property(e => e.DerslikId)
                .ValueGeneratedNever()
                .HasColumnName("DerslikID");
            entity.Property(e => e.DerslikAdi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DerslikTuruId).HasColumnName("DerslikTuruID");
        });

        modelBuilder.Entity<DerslikTuru>(entity =>
        {
            entity.ToTable("DerslikTuru");

            entity.Property(e => e.DerslikTuruId)
                .ValueGeneratedNever()
                .HasColumnName("DerslikTuruID");
            entity.Property(e => e.DerslikTuruAdi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Durum>(entity =>
        {
            entity.ToTable("Durum");

            entity.Property(e => e.DurumId)
                .ValueGeneratedNever()
                .HasColumnName("DurumID");
            entity.Property(e => e.DurumAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");

            entity.Property(e => e.KullaniciId)
                .ValueGeneratedNever()
                .HasColumnName("KullaniciID");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KullaniciTuruId).HasColumnName("KullaniciTuruID");
            entity.Property(e => e.Parola)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<KullaniciTur>(entity =>
        {
            entity.HasKey(e => e.KullaniciTuruId);

            entity.ToTable("KullaniciTur");

            entity.Property(e => e.KullaniciTuruId)
                .ValueGeneratedNever()
                .HasColumnName("KullaniciTuruID");
            entity.Property(e => e.KullaniciTurAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Mufredat>(entity =>
        {
            entity.ToTable("Mufredat");

            entity.Property(e => e.MufredatId)
                .ValueGeneratedNever()
                .HasColumnName("MufredatID");
            entity.Property(e => e.AkademikDonemId).HasColumnName("AkademikDonemID");
            entity.Property(e => e.AkademikYilId).HasColumnName("AkademikYilID");
            entity.Property(e => e.BolumId).HasColumnName("BolumID");
            entity.Property(e => e.DersId).HasColumnName("DersID");
        });

        modelBuilder.Entity<Ogrenci>(entity =>
        {
            entity.ToTable("Ogrenci");

            entity.Property(e => e.OgrenciId).HasColumnName("OgrenciID");
            entity.Property(e => e.Adi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AyrilmaTarihi).HasColumnType("date");
            entity.Property(e => e.BolumId).HasColumnName("BolumID");
            entity.Property(e => e.CinsiyetId).HasColumnName("CinsiyetID");
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.DurumId).HasColumnName("DurumID");
            entity.Property(e => e.KayitTarihi).HasColumnType("date");
            entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
            entity.Property(e => e.OgrenciNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Soyadi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tcno)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCNo");
        });

        modelBuilder.Entity<OgrenimDili>(entity =>
        {
            entity.ToTable("OgrenimDili");

            entity.Property(e => e.OgrenimDiliId)
                .ValueGeneratedNever()
                .HasColumnName("OgrenimDiliID");
            entity.Property(e => e.OgrenimDiliAdi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OgretimElemani>(entity =>
        {
            entity.HasKey(e => e.OgrElmId);

            entity.ToTable("OgretimElemani");

            entity.Property(e => e.OgrElmId)
                .ValueGeneratedNever()
                .HasColumnName("OgrElmID");
            entity.Property(e => e.Adi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BolumId).HasColumnName("BolumID");
            entity.Property(e => e.CinsiyetId).HasColumnName("CinsiyetID");
            entity.Property(e => e.DogumTarihi).HasColumnType("date");
            entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
            entity.Property(e => e.KurumSicilNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Soyadi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TckimlikNo)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TCKimlikNo");
            entity.Property(e => e.UnvanId).HasColumnName("UnvanID");
        });

        modelBuilder.Entity<OgretimTuru>(entity =>
        {
            entity.ToTable("OgretimTuru");

            entity.Property(e => e.OgretimTuruId)
                .ValueGeneratedNever()
                .HasColumnName("OgretimTuruID");
            entity.Property(e => e.OgretimTuruAdi)
                .HasMaxLength(120)
                .IsFixedLength();
        });

        modelBuilder.Entity<ProgramTuru>(entity =>
        {
            entity.ToTable("ProgramTuru");

            entity.Property(e => e.ProgramTuruId)
                .ValueGeneratedNever()
                .HasColumnName("ProgramTuruID");
            entity.Property(e => e.ProgramTuruAdi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<SecilmeDurumu>(entity =>
        {
            entity.ToTable("SecilmeDurumu");

            entity.Property(e => e.SecilmeDurumuId)
                .ValueGeneratedNever()
                .HasColumnName("SecilmeDurumuID");
            entity.Property(e => e.SecilmeDurumuDurum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sinav>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sinav");

            entity.Property(e => e.DersAcmaId).HasColumnName("DersAcmaID");
            entity.Property(e => e.DerslikId).HasColumnName("DerslikID");
            entity.Property(e => e.OgrElmId).HasColumnName("OgrElmID");
            entity.Property(e => e.SinavId).HasColumnName("SinavID");
            entity.Property(e => e.SinavTarihi).HasColumnType("date");
            entity.Property(e => e.SinavTuruId).HasColumnName("SinavTuruID");
        });

        modelBuilder.Entity<SinavTuru>(entity =>
        {
            entity.ToTable("SinavTuru");

            entity.Property(e => e.SinavTuruId)
                .ValueGeneratedNever()
                .HasColumnName("SinavTuruID");
            entity.Property(e => e.SinavTuruTur)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Unvan>(entity =>
        {
            entity.ToTable("Unvan");

            entity.Property(e => e.UnvanId)
                .ValueGeneratedNever()
                .HasColumnName("UnvanID");
            entity.Property(e => e.UnvanAdi)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
