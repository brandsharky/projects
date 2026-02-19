/*
Scripture Memorizer

Brandon Arroyo
1/22/2026

Enhancements: This program randomly selects from a list of scriptures instead of only using one scripture everytime. Also, it only hides words that aren't hidden. In addition, it handles improper user input, like anything other than "quit" or enter by simply looping again.
*/
using System;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();
        Random random = new Random();

        scriptures.Add(new Scripture(new Reference("Moses", 1, 39), "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."));
        scriptures.Add(new Scripture(new Reference("Moses", 7, 18), "And the Lord called his people Zion, because they were of one heart and one mind, and dwelt in righteousness; and there was no poor among them."));
        scriptures.Add(new Scripture(new Reference("Abraham", 2, 9, 11), "And I will make of thee a great nation, and I will bless thee above measure, and make thy name great among all nations, and thou shalt be a blessing unto thy seed after thee, that in their hands they shall bear this ministry and Priesthood unto all nations; And I will bless them through thy name; for as many as receive this Gospel shall be called after thy name, and shall be accounted thy seed, and shall rise up and bless thee, as their father; And I will bless them that bless thee, and curse them that curse thee; and in thee (that is, in thy Priesthood) and in thy seed (that is, thy Priesthood), for I give unto thee a promise that this right shall continue in thee, and in thy seed after thee (that is to say, the literal seed, or the seed of the body) shall all the families of the earth be blessed, even with the blessings of the Gospel, which are the blessings of salvation, even of life eternal."));
        scriptures.Add(new Scripture(new Reference("Abraham", 3, 22, 23), "Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones; And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born."));


        Scripture scripture = scriptures[random.Next(scriptures.Count)];


        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nHit enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }
            if (input != "")
            {
                continue;
            }


            scripture.HideRandomWords(3);


            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }

        Console.WriteLine("\nHave a nice day!");
    }
}