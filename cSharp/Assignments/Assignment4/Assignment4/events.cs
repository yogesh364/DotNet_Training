using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public delegate void ringEventHandler(string name, string phone);
    class mobilePhone
    {
        public event ringEventHandler Onring;

        internal void receiveCall(string name, string phone)
        {
            if (name == "Yogesh" && phone == "9025503722")
            {
                Onring(name, phone);
            }
            else
            {
                Console.WriteLine("No Incoming calls");
            }
        }
    }
    class ringtonePlayer
    {
        internal void ringtone(string name, string phone)
        {
            Console.WriteLine("Playing Ringtone...");
        }

    }

    class screenDisplay
    {
        internal void screen(string name, string phone)
        {
            Console.WriteLine("Displaying caller Information...");
        }
    }

    class vibrationMotor
    {
        internal void vibration(string name, string phone)
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
    class events
    {
        static void Main()
        {
            mobilePhone m = new mobilePhone();
            ringtonePlayer r = new ringtonePlayer();
            screenDisplay s = new screenDisplay();
            vibrationMotor v = new vibrationMotor();

            m.Onring += new ringEventHandler(r.ringtone);
            m.Onring += s.screen;
            m.Onring += v.vibration;
            m.receiveCall("Yogesh", "9025503722");
            Console.ReadLine();

        }
    }
}

