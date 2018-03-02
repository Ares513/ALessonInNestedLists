using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALessonInNestedLists
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Actor> actors = new List<Actor>();
            var harrisonFord = new Actor("Harrison Ford");

            var hanSolo = new Role("Han Solo", "Scoundrel");
            hanSolo.Appearances.Add(DateTime.Now); //close enough
            hanSolo.Appearances.Add(new DateTime(1977, 5, 17));

            harrisonFord.Roles.Add(hanSolo);

            var markHamil = new Actor("Mark Hamil");

            var lukeSkywalker = new Role("Luke Skywalker", "Farmboy");
            lukeSkywalker.Appearances.Add(DateTime.Now);
            lukeSkywalker.Appearances.Add(new DateTime(1978, 2, 1));

            var joker = new Role("Joker", "Psychopath");
            joker.Appearances.Add(DateTime.Now);
            joker.Appearances.Add(new DateTime(1996, 1, 1));
            
            markHamil.Roles.AddRange(new List<Role>(new Role[] { lukeSkywalker, joker }));
            //now let's iterate over them all and collect all the appearances
            var allAppearances = new List<DateTime>();
            foreach(var actor in actors)
            {
                //to access the next, it's pretty simple
                foreach(var role in actor.Roles)
                {
                    //and appearances
                    foreach(var appearance in role.Appearances)
                    {
                        //now we're at the lowest level, appearances
                        //this is pretty ugly; we emit a lot of code and there's room for error,
                        //particularly if you use for instead of foreach
                        allAppearances.Add(appearance);
                    }
                }
            }

            //but what if we wanted to build an aggregation of all of the appearances
            //we would have to create that ugly structure every time
            //but not if we use LINQ!
            //what if we could aggregate with just one function
            var allRoles = actors.Select(a => a.Roles).ToList();
            //unfortunately, we have a list of list of roles
            //also, we need to call .ToList() at the end of our Linq operations
            //because operations don't occur until they have to; this is ideal for performance.
            //Complex operations, like filter, sort, et cetera, can happen faster because logic is not 
            //repeated; operations occur at the same time

            //so we have the roles
            //but what we really want is all the roles in just one list
            var allRolesInOneList = actors.SelectMany(a => a.Roles).ToList();
            //squashes this into a single IEnumerable (which we can turn into a list anytime)

            //well, now we want all appearances as one
            //what's stopping us from just chaining linq statements? nothing!

            var allAppearancesForRealThisTime = actors
                .SelectMany(a => a.Roles) //now we have the roles
                .SelectMany(r => r.Appearances)
                .ToList();

            //what if I wanted to know all the appearances where date is datetime.now?
            //this probably would not work in prod, because... well, Now is always changing
            //(did we just get philosophical?)

            //we can just use the handy dandy Linq Where
            
            var allAppearancesNow = allAppearancesForRealThisTime
                .Where(appearance => appearance == DateTime.Now );
            //here we can apply ANY boolean expression on this object

            //and of course, we need to turn it into a list

            var allAppearancesNowList = allAppearancesNow.ToList();

            //what if a list isn't what we want?

            //what if we we want to be able to instantly look up any actor by their name
            //imagine a situation where there are tens of thousands of actors
            //and we must often look up actors by their name
            //We could write a bunch of code to create a dictionary from this
            //but Linq will actually do this for us.

            var actorsByName = actors.ToDictionary(key => key.Name);
            //we can create a dictionary by any key

            
        }

    }
}
