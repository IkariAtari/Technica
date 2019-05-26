using UnityEngine;

namespace Technica.World
{
    public static class Time
    {
        public static long TotalTicks;
        public static short TicksToSecond;

        public static short Second;
        public static short Minute;
        public static short Hour;
        public static short Day;
        public static short Week;
        public static short Month;
        public static short Year;

        public static long SecondsPassed;
        public static long MinutesPassed;
        public static long HoursPassed;
        public static int DaysPassed;
        public static int WeeksPassed;
        public static int MonthsPassed;
        public static short YearsPassed;

        public static int TimeScale;


        public static bool TimeInit()
        {
            Second = 1;
            Minute = 1;
            Hour = 1;
            Day = 1;
            Week = 1;
            Month = 1;
            Year = 1;        

            return true;
        }

        public static void Timer()
        {                  
                TotalTicks++;

                if(TicksToSecond < TimeScale)
                {
                    TicksToSecond++;
                }
                else
                {
                    TicksToSecond = 0;
                    SecondsPassed++;
                    if(Second < 60)
                    {
                        Second++;
                    }
                    else
                    {
                        Second = 1;
                        MinutesPassed++;
                        if(Minute < 60)
                        {
                            Minute++;
                        }
                        else
                        {
                            Minute = 1;
                            HoursPassed++;
                            if(Hour < 24)
                            {
                                Hour++;
                            }
                            else
                            {
                                Hour = 1;
                                DaysPassed++;
                                if(Day < 30)
                                {
                                    Day++;
                                }
                                else
                                {
                                    Day = 1;
                                    WeeksPassed++;
                                    if(Week < 7)
                                    {
                                        Week++;
                                    }
                                    else
                                    {
                                        Week = 1;
                                        MonthsPassed++;
                                        if(Month < 4)
                                        {
                                           Month++;
                                        }
                                        else
                                        {
                                           Month = 1;
                                           YearsPassed++;
                                           Year++;
                                        }                                       
                                    }
                                }
                            }
                        }
                    }
                }         
        }
    }
}
