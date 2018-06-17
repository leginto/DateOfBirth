using System;

namespace ManiKanta
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			/*
			Console.WriteLine ("Please enter your name:");
			string name = Console.ReadLine ();

			Console.WriteLine ("Enter date of birth(DDMMYYYY):");
			string dob = Console.ReadLine ();
			*/

			// remove this
			string name = "Chandra Sekhar";
			string dob = "18071994";



			Console.Clear ();



			//ageDayss = DateTime.IsLeapYear (presntYear); 



			AllMethods db = new AllMethods ();


			string age = db.GetAge (dob, name);

			db.WaitForSomeTime (5);

			Console.Clear ();

			Console.WriteLine ("Hello " + name);


			Console.WriteLine (age);


			string wishDay = db.NextBirthDayCount (dob);

			Console.WriteLine (wishDay);




			//Console.ReadLine ();

		}
	}


	public class AllMethods
	{
		public void WaitForSomeTime(int t)
		{
			for (int i = t; i > 0; i--) {
				Console.WriteLine (i);
				System.Threading.Thread.Sleep (700);
			}
			Console.WriteLine ("Go ...");
			System.Threading.Thread.Sleep (1000);


		}

		public string NextBirthDayCount(string dob)
		{
			string nextDay;
			int ageMonths;
			int ageDays;

			string timeNow = Convert.ToString(DateTime.UtcNow.ToLocalTime());
			int bornDay = Convert.ToInt32 (dob.Substring (0, 2));
			int bornMonth = Convert.ToInt32 (dob.Substring (2, 2));
			//int bornYear = Convert.ToInt32 (dob.Substring (4, 4));
			int presntDay = Convert.ToInt32 (timeNow.Substring (0, 2));
			int presntMonth = Convert.ToInt32 (timeNow.Substring (3, 2));
			int presntYear = Convert.ToInt32 (timeNow.Substring (6, 4));


			if (presntMonth > bornMonth) {
				nextDay = "Belated Happy Birthday!";
			} else if (presntMonth == bornMonth && presntDay > bornDay) {
				nextDay = "Belated Happy Birthday!";
			} else if (presntMonth == bornMonth && presntDay < bornDay){
				ageDays = bornDay - presntDay;
				ageMonths = 0;

				if (ageMonths!=0) {
					nextDay = "Start arrangments for the comming birth day!\nIn " + ageMonths.ToString () + " Months and " +
						ageDays.ToString () + " Days!";
				} else {
					nextDay = "Start arrangments for the comming birth day!\nIn "+ageDays.ToString () + " Days!";
				}
			}
			else {


				switch (presntMonth) {
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					{
						ageDays = 31 - presntDay + bornDay;
						presntMonth--;

						break;
					}
				case 4:
				case 6:
				case 9:
				case 11:
					{
						ageDays = 30 - presntDay + bornDay;
						presntMonth--;
						break;

					}
				case 2:
					{
						if (DateTime.IsLeapYear (presntYear)) {
							ageDays = 29 - presntDay + bornDay;
							presntMonth--;

						}
						else {
							ageDays = 28 - presntDay + bornDay;
							presntMonth--;

						}
						break;

					}
				default:
					{
						ageDays = 0;
						break;
					}
				}


				ageMonths = bornMonth - presntMonth;

				if (ageMonths!=0) {
					nextDay = "Start arrangments for the comming birth day!\nIn " + ageMonths.ToString () + " Months and " +
						ageDays.ToString () + " Days!";
				} else {
					nextDay = "Start arrangments for the comming birth day!\nIn "+ageDays.ToString () + " Days!";
				}




			}

			return nextDay;

		}

		public string GetAge(string dob, string name)
		{
			string ageNow;

			string timeNow = Convert.ToString(DateTime.UtcNow.ToLocalTime());
			int bornDay = Convert.ToInt32 (dob.Substring (0, 2));
			int bornMonth = Convert.ToInt32 (dob.Substring (2, 2));
			int bornYear = Convert.ToInt32 (dob.Substring (4, 4));
			int presntDay = Convert.ToInt32 (timeNow.Substring (0, 2));
			int presntMonth = Convert.ToInt32 (timeNow.Substring (3, 2));
			int presntYear = Convert.ToInt32 (timeNow.Substring (6, 4));

			if (presntDay == bornDay && presntMonth == bornMonth) {
				Console.WriteLine ("Happy Birth day " + name);
				Console.WriteLine ('\n');
				Console.Write ("Hit enter to continue . . .");
				Console.ReadLine ();
				Console.Clear ();
			}

			int ageDays;
			int ageMonths;
			int ageYears;

			if (presntDay >= bornDay) {
				ageDays = presntDay - bornDay;
			} else {
				switch (presntMonth) {
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					{
						ageDays = 31 + presntDay - bornDay;
						presntMonth--;
						if (presntMonth == 0) {
							presntYear--;
						}
						break;
					}
				case 4:
				case 6:
				case 9:
				case 11:
					{
						ageDays = 30 + presntDay - bornDay;
						presntMonth--;
						if (presntMonth == 0) {
							presntYear--;
						}
						break;

					}
				case 2:
					{
						if (DateTime.IsLeapYear (presntYear)) {
							ageDays = 29 + presntDay - bornDay;
							presntMonth--;
							if (presntMonth == 0) {
								presntYear--;
							} 
						}
						else {
							ageDays = 28 + presntDay - bornDay;
							presntMonth--;
							if (presntMonth == 0) {
								presntYear--;
							}
						}
						break;

					}
				default:
					{
						ageDays = 0;
						break;
					}
				}
			}

			if (presntMonth >= bornMonth) {
				ageMonths = presntMonth - bornMonth;
			} else {
				ageMonths = 12 + presntMonth - bornMonth;
				presntYear--;
			}


			if (presntYear < bornYear) {
				Console.WriteLine ("You are yet to born or your device time is incorrect");
				return "\0\0";

			} else {
				ageYears = presntYear - bornYear;
			}

			ageNow = "Your age is "+ageYears.ToString () + " Years, " + ageMonths.ToString () + " Months, and " + ageDays.ToString () + " Days";

			return ageNow;


		}
	}



}

/* 
 * Requrements

1. Ask name
2. Ask dob
3. Clear the screen
4. Get time from net
5. If fails tell the situation
6. Wait for 5sec by giving count down
7. Get time from system
8. Check birthday is over or not
8.1 if over belated happy birthday and show age including days
9. If not tell, in how many days birthday will come and give current age
10. Ask want to exit or try again. Repeat the same again.

*/
