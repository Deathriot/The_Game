using MyTools;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace The_Witch_Tale
{
    public enum QuestName
    {
        MainQuest = 0,
        ElfsQuest = 1,
        WifeQuest = 2,
        DaddyBrick = 3
    }
    public abstract class Quest
    {
        public QuestName QuestName;
        public string Title;
        public string Description;
        public abstract void Reward(Character hero);
    }
    public class MainQuest : Quest
    {
        public MainQuest()
        {
            Title = "/Куда я попал?/";
            Description = "Вы попали в в мистическое место, где царит смерть и упадок. Не этого вы ожидали, спускаясь в легендарное подземелье Люцифрона..." +
                "\nНужно выяснить, как отсюда выбраться.";
            QuestName = QuestName.MainQuest;
        }
        public override void Reward(Character hero)
        {

        }
    }
    public class ElfsQuest : Quest
    {
        public ElfsQuest()
        {
            Title = "/Горе эльфа/";
            Description = "Вы обнаружили вычурного эльфа в этом залахустье. Он говорит, что что-то у него украли, но не хочет признаваться что. \nНеплохо бы было поискать вора.";
            QuestName = QuestName.ElfsQuest;
        }
        public override void Reward(Character hero)
        {

        }
    }
    public class WifeQuest : Quest
    {
        public WifeQuest()
        {
            Title = "/Похотливый камень/";
            Description = "Алтарь захотел жену, наверняка здесь вы найдете еще кучу говорливых камушков.";
            QuestName = QuestName.WifeQuest;
        }
        public const string AddAfterClear = "Кажется, вы освободили этот несчастный алтарик от проклятия, который она сама же и навлекла на себя. " +
            "\nНаверное, сейчас она будет посговорчевее.";
        public const string AddWifeIsReady = "Вы взяли подмышку алтарик, осталось лишь отнести ее к заказчику.";
        public const string WrongWife = "Что ж, вряд ли бы эта мамашная кирпичка понравилась вашему другу, так что вы наверное ничего не потеряли...";
        public const string WifeRejected = "Что вас дернуло не отдавать ему эту алтариху? Ну, дело ваше, может оно и к лучшему";

        public static bool WifeIsReady = false; // проверка если ли у вас с собой альтарь-жена
        public static bool FirstTimeReject = true; // Первый отказ отдать жену
        public override void Reward(Character hero)
        {
            hero.Levelup(100);
        }
    }
    public class DaddyQuest : Quest
    {
        public DaddyQuest()
        {
            Title = "/Папочка зол/";
            Description = "Вас отмудохал богоподобный кирпич. Нужно выяснить, как ему отомстить.";
            QuestName = QuestName.DaddyBrick;
        }
        public override void Reward(Character hero)
        {

        }
    }
}
