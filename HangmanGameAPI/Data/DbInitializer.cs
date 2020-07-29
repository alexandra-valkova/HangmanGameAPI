using HangmanGameAPI.Models;
using System.Linq;

namespace HangmanGameAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(HangmanGameContext context)
        {
            // CHECK IF DATABASE EXISTS

            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            // USERS

            var users = new User[]
            {
                new User { Username = "admin", Email = "admin@admin.com", Password = "admin" },
                new User { Username = "alexandra", Email = "alexandra.valkova.97@gmail.com", Password = "alexandra" }
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            // WORDS

            string wordsString = @"ORANGE,HOLIDAY,BULB,PALTRY,FLESH,KILL,HEAT,SPOTLESS,HEARTBREAKING,SHORT,TRICK,
                                DISGUSTING,BELLS,STOVE,CONTINUE,TYPICAL,DECORATE,NICE,REGRET,TEACHING,
                                DISGUSTED,SAND,DELIGHT,ARM,NUTTY,CONFUSE,REPLY,TOUCH,CLIP,TRUTHFUL,
                                QUESTION,SUSPECT,DRIVING,EXPLODE,MATE,FLY,THAW,ABUSIVE,CHEAT,WOOD,NUMBER,
                                LAND,SIMPLE,HORSE,SPECTACULAR,CABBAGE,UNKNOWN,LEGAL,BADGE,VAGABOND,ROUTE,
                                SOOTHE,CAN,VENGEFUL,TICKET,STEEP,SECOND-HAND,DEER,CANNON,HOUSES,PART,LEAN,MAN,
                                TOE,SHADE,ROAD,SQUEAK,GIRL,NECESSARY,GHOST,FROG,HYPNOTIC,TRICKY,ELBOW,TEETH,
                                SAD,INFAMOUS,CUTE,HESITANT,LEG,STRING,COUNTRY,LARGE,SLEEPY,PRODUCTIVE,ZIP,
                                STAGE,BITE,STAMP,DOLL,ADHESIVE,CAUSE,FLIPPANT,REPLACE,MIDDLE,AIRPORT,THROAT,
                                BRAKE,FESTIVE,GLAMOROUS";

            string[] wordsArray = wordsString.Split(',').Select(w => w.Trim()).ToArray();

            foreach (string w in wordsArray)
            {
                var word = new Word { Text = w };
                context.Words.Add(word);
            }

            context.SaveChanges();
        }
    }
}
