using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MoviesNetCore.Data;

namespace MoviesNetCore.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20160523050609_movieMigration")]
    partial class movieMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("MoviesNetCore.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<int>("Classification");

                    b.Property<string>("CoverPhoto");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<int>("Format");

                    b.Property<string>("ReleaseYear");

                    b.Property<TimeSpan>("RunningTime");

                    b.Property<bool>("TVRecording");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
        }
    }
}
