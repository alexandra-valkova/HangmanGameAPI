using HangmanGameAPI.Models;

namespace HangmanGameAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(HangmanGameContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            // USERS

            User admin = new()
            {
                Username = "admin",
                Email = "admin@admin.com",
                Password = "admin"
            };

            User player = new()
            {
                Username = "alexandra",
                Email = "alexandra.valkova.97@gmail.com",
                Password = "alexandra"
            };

            context.AddRange(admin, player);
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

            IEnumerable<Word> words = wordsString.Split(',')
                                                 .Select(word => new Word { Text = word.Trim() });

            context.Words.AddRange(words);
            context.SaveChanges();
        }
    }
}
