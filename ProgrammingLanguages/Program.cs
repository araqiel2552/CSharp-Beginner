using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      List<Language> languages = File.ReadAllLines("./languages.tsv")
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

        // #1
        foreach (var language in languages)
        {
          Console.WriteLine(language.Prettify());
        }

        // #2
        var descriptions = languages.Select(language => $"{language.Name} was created in ${language.Year} by {language.ChiefDeveloper}.");
        foreach (var description in descriptions)
        {
          Console.WriteLine(description);
        }

        // #3
        Console.WriteLine(languages.Where(language => language.Name == "C#").First().Prettify());

        // #4
        var microsoftLanguages = languages.Where(language => language.ChiefDeveloper.Contains("Microsoft"));
        foreach (var microsoftLanguage in microsoftLanguages)
        {
          Console.WriteLine(microsoftLanguage.Prettify());
        }

        // #5 
        var lispSuccessors = languages.Where(language => language.Predecessors.Contains("Lisp"));
        foreach (var lispSuccessor in lispSuccessors)
        {
          Console.WriteLine(lispSuccessor.Prettify());
        }

        // #6
        var scripts = languages.Where(language => language.Name.Contains("Script")).Select(language => language.Name);
        foreach (var script in scripts)
        {
          Console.WriteLine(script);
        }

        // #7
        Console.WriteLine(languages.Count());

        // #8
        var milleniums = languages.Where(language => language.Year > 1994 && language.Year < 2006);
        Console.WriteLine(milleniums.Count());

        // #9
        var milleniumsDates = milleniums.Select(millenium => $"{millenium.Name} was invented in {millenium.Year}.");
         foreach (var milleniumsDate in milleniumsDates)
        {
          Console.WriteLine(milleniumsDate);
        }

        // #10
        Language.PrettyPrintAll(languages);

        // #11

    }

    public static void PrintAll(IEnumerable<Object> elements)
    {
          foreach (var element in elements)
      {
        Console.WriteLine(element);
      }
    }
  }
}
