# README for AnimeRouletteAPI

# Pre steps
Installed 4 `NuGet Packages`

- Microsoft.EntityFrameworkCore v.5.0.7
- Microsoft.EntityFrameworkCore v.5.0.7
- Microsoft.EntityFrameworkCore v.5.0.7
- Microsoft.EntityFrameworkCore v.5.0.7

# Setting up Database
Created `Models` folder which contains the classes that are the `database` tables

1. Anime.cs
2. Category.cs
3. AppUser.cs

## Modifying `appsetting.json`
Created `connectionstring` which for now refers to default database, using `MS SQL`

## Modifying `Startup.cs`
Made invocation and getting connectionstring

## Foreign key constraints
Tried to link both `Anime` table with `Category` table in a one-to-many relationship.

## NuGet Package Manager
In the console manager:

 `add-migration NameOfProcess` <-- creates migration file

 Followed by

 `update-database` <--updates the database to have the database and tables

#### Warning thrown
```
Microsoft.EntityFrameworkCore.Model[10613]
      The relationship was separated into two relationships because the [ForeignKey] attribute specified on the navigation 'Anime.Categories' doesn't match the [ForeignKey] attribute specified on the property 'Category.Genre'.
Microsoft.EntityFrameworkCore.Model[10613]
      The relationship was separated into two relationships because the [ForeignKey] attribute specified on the navigation 'Anime.Categories' doesn't match the [ForeignKey] attribute specified on the property 'Category.Genre'.
```

### Links used
About configuring [relationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key) and also [this](https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx)
