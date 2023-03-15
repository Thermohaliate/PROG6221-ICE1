using System;
using System.Linq;

namespace Task_1 {
	internal class Program {
		public static void Main() {
			int lecturers = GetLecturers();
			int[] scripts = GetScripts(lecturers);
			int questions = GetQuestions();
			int[] subtotals = GetSubtotals(questions);

			for (int i = 0; i < lecturers; i++) {
				int seconds;

				if (i + 1 != lecturers) {
					seconds = scripts[0] * subtotals.Sum() * 2;
				} else {
					seconds = (scripts[0] + scripts[1]) * subtotals.Sum() * 2;
				}

				int minutes = (int) (
					Math.Floor((double) (seconds / 60))
					+ (seconds % 60 > 30 ? 1 : 0)
				);
				int hours = (int) Math.Floor((double) (minutes / 60));

				Console.WriteLine(
					"Lecturer {0}: {1} ({2}h {3}m)",
					i + 1,
					scripts[0],
					hours,
					minutes % 60
				);
			}
		}

		private static int GetLecturers() {
			while (true) {
				Console.Write("Number of lecturers: ");

				if (int.TryParse(Console.ReadLine(), out int num)) {
					if (num > 0) {
						return num;
					}
				}

				Console.WriteLine("Lecturers must be greater than 0");
			}
		}

		private static int[] GetScripts(int lecturers) {
			while (true) {
				Console.Write("Number of scripts: ");

				if (int.TryParse(Console.ReadLine(), out int num)) {
					if (num > 0) {
						return new int[] {
							(int) Math.Floor((double) (num / lecturers)),
							num % lecturers
						};
					}
				}

				Console.WriteLine("Scripts must be greater than 0");
			}
		}

		private static int GetQuestions() {
			while (true) {
				Console.Write("Number of questions: ");

				if (int.TryParse(Console.ReadLine(), out int num)) {
					if (num > 0 && num < 11) {
						return num;
					}
				}

				Console.WriteLine("Questions must be greater than 0 and less than 11");
			}
		}

		private static int[] GetSubtotals(int questions) {
			int[] subtotals = new int[questions];

			Console.WriteLine("Question subtotals:");

			for (int i = 0; i < questions; i++) {
				while (true) {
					Console.Write("\tQuestion {0}: ", i + 1);

					if (int.TryParse(Console.ReadLine(), out int num)) {
						if (num > 0) {
							subtotals[i] = num;

							break;
						}
					}

					Console.WriteLine("Invalid value");
				}
			}

			return subtotals;
		}
	}
}
