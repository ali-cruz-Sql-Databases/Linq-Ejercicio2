using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

var fileOffice = await File.ReadAllTextAsync("Oficinas.json");
var Oficinas = JsonSerializer.Deserialize<List<OfficeData>>(fileOffice);

var fileOfficeAssign = await File.ReadAllTextAsync("AsignacionOficinas.json");
var AsignacionesOficina = JsonSerializer.Deserialize<List<OfficeAssignData>>(fileOfficeAssign);



// Uso de StartsWith - Linq
Console.WriteLine("Uso de StartsWith - Linq");
string[] Countries = { "USA", "Canada", "United Kingdom", "Mexico", "China", "Uruguay" };

var listSelect = new List<string>();

var ieSelect1 = from c in Countries
                where c.StartsWith("U")
                select c;

var ieSelect = Countries.Where(p => p.StartsWith("U"));

    
foreach (string item in Countries)
{
    if (item.StartsWith("U"))
    {
    listSelect.Add(item);
    }
}

foreach (var item in ieSelect)
{
    Console.WriteLine(item);    
}

Console.WriteLine("// Uso de StartsWith - Linq \n\n");



// Uso de OrderBy - Linq
Console.WriteLine("Uso de OrderBy - Linq");
int[] numeros = { 19, 5, 7, 3, 43, 34 };

var orderedNumbers = from n in numeros
                        orderby n
                        select n;

var orderedNumbers2 = numeros.OrderBy(n => n);

foreach (var item in orderedNumbers2)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de OrderBy - Linq \n");


// Uso de OrderBy 2 -Linq
Console.WriteLine("Uso de OrderBy 2 -Linq");
List<People> peoples = new List<People>
{
    new People{Name = "TDF", Age = 31},
    new People{Name = "Ali", Age = 33},
    new People{Name = "Sara", Age = 15}
};

var listSorted = from p in peoples
            orderby p.Name
            select p;

var listSorted2 = peoples.OrderBy(p => p.Name);

foreach (var item in listSorted2)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("// Uso de OrderBy 2 -Linq \n");

// Uso de Filtros - Linq
Console.WriteLine("Uso de Filtros - Linq");
List<People> peopleList = new List<People>
{
    new People {Name = "Sara", Age = 15},
    new People {Name = "Chano", Age = 31 },
    new People {Name = "Belen", Age = 25 },
    new People {Name = "Nef", Age = 35 },
    new People {Name = "Cris", Age = 37 },
    new People {Name = "Eme", Age = 65},
    new People {Name = "Fel", Age = 67}
};

var listFiltered = from p in peopleList
                   where p.Age == 25
            select p;

var listFiltered2 = peopleList.Where(p => p.Age == 25);

foreach (var item in listFiltered2)
{
    Console.WriteLine(item.Name + " : " + item.Age);
}
Console.WriteLine("// Uso de Filtros - Linq \n");




// Uso de Except (Diferencia) - Linq
Console.WriteLine("Uso de Except (Diferencia) - Linq");
string[] Female = { "Martha", "Dora", "Jane", "Tim", "Tom", "Ben" };
string[] Male = { "Tim", "Tom", "Ben" };

var listWithOutMale = Female.Except(Male);

foreach (var item in listWithOutMale)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de Except (Diferencia) - Linq \n \n");



// Uso de Intersect - Linq
Console.WriteLine("Uso de Intersect - Linq");
string[] Female2 = { "Martha", "Dora", "Jane", "Tim" };
string[] Male2 = { "Tim", "Tom", "Martha", "Joe" };

var intersectionLinq = Female2.Intersect(Male2);

foreach (var item in intersectionLinq)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de Intersect - Linq \n \n");


// Uso de Union - Linq
Console.WriteLine("Uso de Union - Linq");
string[] Female3 = { "Martha", "Dora", "Jane", "Tim" };
string[] Male3 = { "Tim", "Tom", "Ben", "Dora" };

var listUnion = Female3.Union(Male3);

foreach (var item in listUnion)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de Union - Linq \n\n");


// Uso de Take - Linq
Console.WriteLine("Uso de Take - Linq");
int[] numerosTake = { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

var listTake = numerosTake.Take(3);

foreach (var item in listTake)
{
    Console.WriteLine(item);
}
Console.WriteLine("// Uso de Take - Linq \n\n");



// Uso de Skip - Linq
Console.WriteLine("Uso de Skip - Linq");
int[] numerosSkip = { 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// cuenta el índice, no el valor.
var listSkip = numerosSkip.Skip(6);

foreach (var item in listSkip)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de Skip - Linq \n\n");


// Uso de TakeWhile - Linq
Console.WriteLine("Uso de TakeWhile - Linq");
int[] numerosTakeWhile = { 1, 1, 2, 3, 3, 3, 4, 4, 5, 6, 7, 8, 9 };

// Toma el valor, no el indice.
var listTakeWhile = numerosTakeWhile.TakeWhile(n => n <= 4);

foreach (var item in listTakeWhile)
{
    Console.WriteLine(item);
}

Console.WriteLine("// Uso de TakeWhile - Linq \n\n");



// Uso de SkipWhile - Linq
Console.WriteLine("Uso de SkipWhile - Linq");
int[] numerosSkipWhile = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

var listSkipWhile = numerosSkipWhile.SkipWhile(n => n != 8);

foreach (var item in listSkipWhile)
{
    Console.WriteLine(item);
}

Console.WriteLine("Uso de SkipWhile - Linq \n\n");


// Uso de GroupBy 2 - Linq
Console.WriteLine("// Uso de GroupBy 2 - Linq");
List<People> listPeopleGroupBy = new List<People>
{
    new People{Name = "Ali", Age = 33},
    new People {Name = "Sara", Age = 9},
    new People {Name = "Nef", Age = 35},
    new People {Name = "Cris", Age = 35},
    new People {Name = "Eme", Age = 66},
    new People {Name = "Chano", Age = 33}
};

var gruposDePersonas = listPeopleGroupBy.GroupBy(p =>
{
    if (p.Age <= 20)
    {
        return "Menor que 20";
    }
    else if (p.Age >= 21 && p.Age <= 40)
    {
        return "Entre 21 y 40";
    }
    else
    {
        return "Mayores de 41";
    }
});

Console.WriteLine("Uso de switch \n");
listPeopleGroupBy.GroupBy(p => p.Age switch
{
    <= 20 => "Menor de 20",
    <= 40 => "Menor de 40",
    _ => "Mayor de 41"
})
    .Select(p => new
    {
        Edad = p.Key,
        Cantidad = p.Count()
    })
    .ToList()
    .ForEach(item => Console.WriteLine($"{item.Edad} : {item.Cantidad}"));

Console.WriteLine("\n\n Uso de if");
foreach (var grupoPersona in gruposDePersonas)
{
    Console.WriteLine("Grupo de " + grupoPersona.Key + " : cantidad " + grupoPersona.Count());
    foreach (var persona in grupoPersona)
    {
        Console.WriteLine(persona.Name);
    }
}

Console.WriteLine("// Uso de GroupBy 2 - Linq \n\n");


// Uso de dos fuentes de datos:
//Console.WriteLine("Uso de dos fuentes de datos:: \n");

//// Print all office with 'EsHabilitado' = 1
Console.WriteLine("Print all office with 'EsHabilitado' = 1");
var oficinasList = Oficinas
        .Where(o => o.EsHabilitado == 1)
        .Select(o => new
        {
            ID = o.ID,
            NombreOficina = o.Nombre,
            TotMovimientos = AsignacionesOficina
                                .Where(a => a.OficinaID == o.ID)
                                .Count(),
            UltimoMovimiento = AsignacionesOficina
                                //.Where(a => a.OficinaID == o.ID || (o.ID == null && a.OficinaID == null))
                                //.Where(object.Equals(AsignacionesOficina.OficinaID, Oficinas.Id)

                                //.Where(a => 
                                //{
                                //    if (o.ID != a.OficinaID)
                                //    {
                                //        return "sin dato";
                                //    }
                                //})
                                //.Where(a => 
                                //{
                                //    if (o.ID == a.OficinaID)
                                //    {
                                //        o.ID = o.ID;
                                //    } else
                                //    {
                                //        o.ID = 1;                                      
                                //    }
                                //    return true;
                                //})
                                .Where(a => a.OficinaID == o.ID)
                                .OrderByDescending(a => a.ID)
                                .FirstOrDefault()
        })
        .ToList();

foreach (var item in oficinasList)
{
    if (item.UltimoMovimiento == null)
    {
        Console.WriteLine($"\n{item.ID} : " +
    $"{item.NombreOficina} : {item.TotMovimientos} :::: " +
    $"{item.UltimoMovimiento } ::::");
    } else
    {
        Console.WriteLine($"\n{item.ID} : " +
    $"{item.NombreOficina} : {item.TotMovimientos} :::: " +
    $"{item.UltimoMovimiento.Movimiento } ::::");
    }

}




Console.WriteLine("\n// Print all office with 'EsHabilitado' = 1\n\n");

// Print one value from AsignacionesOficina
Console.WriteLine("\nPrint one value from AsignacionesOficina\n");

// Obtengo el objeto con sus propiedades para tomar la propiedad necesaria
var res = AsignacionesOficina
    .Where(a => a.OficinaID == 4)
    .OrderByDescending(a => a.ID)
    .Select(a => a.Movimiento);    

if (res == null)
{
    Console.WriteLine($"\n*** NULL *** {res} ***\n\n");
} else
{
    Console.WriteLine($"\n*** NO NULL *** {res.ToString()} ***\n\n");
}



//foreach (var item in res)
//{
//    Console.WriteLine(item);
//}


Console.WriteLine("\n// Print one value from AsignacionesOficina\n\n");

class OfficeData
{
    [JsonPropertyName("Id")]
    public int ID { get; set; }

    public int EsHabilitado { get; set; }

    [JsonPropertyName("DepartamentosID")]
    public int DepartamentoID { get; set; }

    [JsonPropertyName("SecretariasID")]
    public int SecretariaID { get; set; }

    public string Nombre { get; set; }

    public string Ubicacion { get; set; }

    public DateTime FechaAlta { get; set; } 

    public DateTime FechaActualizacion { get; set; }
}

class OfficeAssignData
{
    [JsonPropertyName("Id")]
    public int ID { get; set; }

    [JsonPropertyName("UsuariosID")]
    public int UsuarioID { get; set; }

    [JsonPropertyName("OficinasID")]
    public int OficinaID { get; set; }

    public int Movimiento { get; set; }

    public int AutorID { get; set; }

    public DateTime FechaAlta { get; set; }
}


class People
{
    public int Clave { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}