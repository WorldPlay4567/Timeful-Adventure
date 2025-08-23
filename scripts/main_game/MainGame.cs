
using Godot;
namespace ClassMainGame
{
    public partial class MainGame : Node {
        public static string newScene;
        static bool isTimeStop = false;
        static bool isPlayGame = true;
        
        public static void setTimeStop(bool _setTimeStop)
        {
            if (isPlayGame)
            {
                isTimeStop = _setTimeStop;
            }
            else
            {
                GD.Print("Невозможно изменить ТаймСтоп, пока игра не началась");
            }
        }

        public static bool getTimeStop() {
            return isTimeStop;
        }
    }

}