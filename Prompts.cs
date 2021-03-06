using System;
using System.IO;
using System.Text;
namespace mis221_pa5_Dnsavage
{
    public class Prompts
    {
        private string prompts;
        public static int languageID;
        public static int displayID = 1;
        public static int optionsID = 2;
        public static int count;
        //No args constructor for Prompts
        public Prompts()
        {

        }
        //Constructor for Prompts
        public Prompts(string prompts)
        {
            this.prompts = prompts;
        }
        //Sets prompts
        public void SetPrompts(string prompts)
        {
            this.prompts = prompts;
        }
        //Returns prompts when called
        public string GetPrompts()
        {
            return prompts;
        }
        //Sets the language ID
        public static void SetLanguageID(int languageID)
        {
            Prompts.languageID = languageID;
        }
        //Returns the language ID when called
        public static int GetLanguageID()
        {
            return languageID;
        }
        //Return Display ID when called
        public static int GetDisplayID()
        {
            return displayID;
        }
        //Return options ID when called
        public static int GetOptionsID()
        {
            return optionsID;
        }
        //Return count when called
        public static int GetCount()
        {
            return count;
        }
        //Sets the count
        public static void SetCount(int count)
        {
            Prompts.count = count;
        }
        //Increments Count by 1
        public static void IncCount()
        {
            count++;
        }

        public static void PromptMissingFiles()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Error: You are missing the following files:");
            Console.WriteLine("Error: faltan los siguientes archivos:");
            Console.WriteLine("Erreur : Il vous manque les fichiers suivants :");
            Console.WriteLine("Fehler: Ihnen fehlen die folgenden Dateien:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public static void PromptRestoreFiles()
        {
            Console.ResetColor();
            Console.WriteLine("Please restore the missing files. Press enter to exit.");
            Console.WriteLine("Restaure los archivos que faltan. Presione enter para salir.");
            Console.WriteLine("Veuillez restaurer les fichiers manquants. Appuyez sur Entr??e pour sortir.");
            Console.WriteLine("Bitte stellen Sie die fehlenden Dateien wieder her. Dr??cken Sie zum Beenden die Eingabetaste.");
            Console.ReadLine();
        }

        public static void MainMenuPrompt()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Press enter to return to Main Menu");
                    break;
                case 2: Console.WriteLine("Presione enter para regresar al men?? principal");
                    break;
                case 3: Console.WriteLine("Appuyez sur entr??e pour revenir au menu principal");
                    break;
                default: Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Hauptmen?? zur??ckzukehren");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void NoneIncompleted()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any incomplete activities!");
                    break;
                case 2: Console.WriteLine("??No tienes ninguna actividad incompleta!");
                    break;
                case 3: Console.WriteLine("Vous n'avez aucune activit?? incompl??te !");
                    break;
                default: Console.WriteLine("Sie haben keine unvollst??ndigen Aktivit??ten!");
                    break;
            }
            MainMenuPrompt();
        }

        public static void NoneCompleted()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any completed activities!");
                    break;
                case 2: Console.WriteLine("??No tienes ninguna actividad completada!");
                    break;
                case 3: Console.WriteLine("Vous n'avez aucune activit?? termin??e !");
                    break;
                default: Console.WriteLine("Sie haben keine abgeschlossenen Aktivit??ten!");
                    break;
            }
            MainMenuPrompt();
        }

        public static void NoneRecommended()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any recommended activities!");
                    break;
                case 2: Console.WriteLine("??No tienes ninguna actividad recomendada!");
                    break;
                case 3: Console.WriteLine("Vous n'avez aucune activit?? recommand??e !");
                    break;
                default: Console.WriteLine("Sie haben keine empfohlenen Aktivit??ten!");
                    break;
            }
            MainMenuPrompt();
        }

        public static void ReportSuccessful()
        {
            Console.Clear();
            Console.WriteLine("Report saved successfully!");
            MainMenuPrompt();
        }

        public static void SummaryReportLocation()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Your report can be found in the file titled ""ByDayReport.txt""");
                    break;
                case 2: Console.WriteLine(@"Su informe se puede encontrar en el archivo titulado ""ByDayReport.txt""");
                    break;
                case 3: Console.WriteLine(@"Votre rapport se trouve dans le fichier intitul?? ""ByDayReport.txt""");
                    break;
                default: Console.WriteLine(@"Ihren Bericht finden Sie in der Datei ""ByDayReport.txt""");
                    break;
            }
        }

        public static void SummaryReportFailed()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Error: Output file ""ByDayReport.txt"" not found");
                    break;
                case 2: Console.WriteLine(@"Error: archivo de salida ""ByDayReport.txt"" no encontrado");
                    break;
                case 3: Console.WriteLine(@"Erreur : fichier de sortie ""ByDayReport.txt"" introuvable");
                    break;
                default: Console.WriteLine(@"Fehler: Ausgabedatei ""ByDayReport.txt"" nicht gefunden");
                    break;
            }
            MainMenuPrompt();
        }

        public static void IncompleteReportLocation()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Your report can be found in the file titled ""IncompleteReport.txt""");
                    break;
                case 2: Console.WriteLine(@"Su informe se puede encontrar en el archivo titulado ""IncompleteReport.txt""");
                    break;
                case 3: Console.WriteLine(@"Votre rapport se trouve dans le fichier intitul?? ""IncompleteReport.txt""");
                    break;
                default: Console.WriteLine(@"Ihren Bericht finden Sie in der Datei ""IncompleteReport.txt""");
                    break;
            }
        }

        public static void IncompleteReportFailed()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Error: Output file ""IncompleteReport.txt"" not found");
                    break;
                case 2: Console.WriteLine(@"Error: archivo de salida ""IncompleteReport.txt"" no encontrado");
                    break;
                case 3: Console.WriteLine(@"Erreur : fichier de sortie ""IncompleteReport.txt"" introuvable");
                    break;
                default: Console.WriteLine(@"Fehler: Ausgabedatei ""IncompleteReport.txt"" nicht gefunden");
                    break;
            }
            MainMenuPrompt();
        }

        public static void FavoritesReportLocation()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Your report can be found in the file titled ""FavActivities.txt""");
                    break;
                case 2: Console.WriteLine(@"Su informe se puede encontrar en el archivo titulado ""FavActivities.txt""");
                    break;
                case 3: Console.WriteLine(@"Votre rapport se trouve dans le fichier intitul?? ""FavActivities.txt""");
                    break;
                default: Console.WriteLine(@"Ihren Bericht finden Sie in der Datei ""FavActivities.txt""");
                    break;
            }
        }

        public static void FavoritesReportFailed()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Error: Output file ""FavActivities.txt"" not found");
                    break;
                case 2: Console.WriteLine(@"Error: archivo de salida ""FavActivities.txt"" no encontrado");
                    break;
                case 3: Console.WriteLine(@"Erreur : fichier de sortie ""FavActivities.txt"" introuvable");
                    break;
                default: Console.WriteLine(@"Fehler: Ausgabedatei ""FavActivities.txt"" nicht gefunden");
                    break;
            }
            MainMenuPrompt();
        }

        public static void RecommendReportLocation()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Your report can be found in the file titled ""Recommendations.txt""");
                    break;
                case 2: Console.WriteLine(@"Su informe se puede encontrar en el archivo titulado ""Recommendations.txt""");
                    break;
                case 3: Console.WriteLine(@"Votre rapport se trouve dans le fichier intitul?? ""Recommendations.txt""");
                    break;
                default: Console.WriteLine(@"Ihren Bericht finden Sie in der Datei ""Recommendations.txt""");
                    break;
            }
        }

        public static void RecommendReportFailed()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Error: Output file ""Recommendations.txt"" not found");
                    break;
                case 2: Console.WriteLine(@"Error: archivo de salida ""Recommendations.txt"" no encontrado");
                    break;
                case 3: Console.WriteLine(@"Erreur : fichier de sortie ""Recommendations.txt"" introuvable");
                    break;
                default: Console.WriteLine(@"Fehler: Ausgabedatei ""Recommendations.txt"" nicht gefunden");
                    break;
            }
            MainMenuPrompt();
        }

        public static void SpendingReportLocation()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Your report can be found in the file titled ""SpendingReport.txt""");
                    break;
                case 2: Console.WriteLine(@"Su informe se puede encontrar en el archivo titulado ""SpendingReport.txt""");
                    break;
                case 3: Console.WriteLine(@"Votre rapport se trouve dans le fichier intitul?? ""SpendingReport.txt""");
                    break;
                default: Console.WriteLine(@"Ihren Bericht finden Sie in der Datei ""SpendingReport.txt""");
                    break;
            }
        }

        public static void SpendingReportFailed()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine(@"Error: Output file ""SpendingReport.txt"" not found");
                    break;
                case 2: Console.WriteLine(@"Error: archivo de salida ""SpendingReport.txt"" no encontrado");
                    break;
                case 3: Console.WriteLine(@"Erreur : fichier de sortie ""SpendingReport.txt"" introuvable");
                    break;
                default: Console.WriteLine(@"Fehler: Ausgabedatei ""SpendingReport.txt"" nicht gefunden");
                    break;
            }
            MainMenuPrompt();
        }
        //Return total spent in the current language
        public static string SpendingReportTotal()
        {
            switch(GetLanguageID())
            {
                case 1: return $"Total Spent: ${Spending.GetTotalSpent()}";
                case 2: return $"Total gastado: ${Spending.GetTotalSpent()}";
                case 3: return $"Total d??pens?? : ${Spending.GetTotalSpent()}";
                default: return $"Gesamtausgaben: ${Spending.GetTotalSpent()}";
            }
        }

        public static void LanguageMenu()
        {
            Console.Clear();
            Console.WriteLine("Select your preferred language:");
            Console.WriteLine("1.) English (Ingl??s, Anglais, Englisch)");
            Console.WriteLine("2.) Espa??ol (Spanish, Espagnol, Spanisch)");
            Console.WriteLine("3.) fran??ais (French, Franc??s, Franz??sisch)");
            Console.WriteLine("4.) Deutsch (German, Alem??n, Allemand)");
        }

        public static string[] LanguageOptions()
        {
            string[] options = {"1.) English", "2.) Spanish", "3.) French", "4.) German (Standard)"};
            return options;
        }

        public static void PromptForVacID()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please enter the ID of a vacation to edit/delete. Enter 'stop' to go back.");
                    break;
                case 2: Console.Write("Ingrese el ID de vacaciones para editar / eliminar. ");
                    Console.WriteLine("Ingrese 'stop' para regresar.");
                    break;
                case 3: Console.Write("Veuillez saisir l'ID des vacances ?? modifier/supprimer. ");
                    Console.WriteLine("Entrez ?? stop ?? pour revenir en arri??re.");
                    break;
                default: Console.Write("Bitte geben Sie die ID eines Urlaubs zum Bearbeiten/L??schen ein. ");
                    Console.WriteLine("Geben Sie ???stop??? ein, um zur??ckzugehen.");
                    break;
            }
        }

        public static void PromptDestination()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter Destination. Enter 'stop' to abort.");
                    break;
                case 2: Console.Write("Ingrese Destino. Ingrese 'stop' para abortar.");
                    break;
                case 3: Console.Write("Entrez la destination. Entrez 'stop' pour annuler.");
                    break;
                default: Console.Write("Geben Sie das Ziel ein. Geben Sie 'stop' ein, um abzubrechen.");
                    break;
            }
        }

        public static void PromptStartDate()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter Start Date (MM/DD/YYYY). Enter 'stop' to abort.");
                    break;
                case 2: Console.Write("Ingrese la fecha de inicio (MM/DD/AAAA). Ingrese 'stop' para abortar.");
                    break;
                case 3: Console.Write("Entrez la date de d??but (MM/JJ/AAAA). Entrez 'stop' pour annuler.");
                    break;
                default: Console.Write("Geben Sie das Startdatum ein (MM/TT/JJJJ). Geben Sie 'stop' ein, um abzubrechen.");
                    break;
            }
        }

        public static void PromptEndDate()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter End Date (MM/DD/YYYY). Enter 'stop' to abort.");
                    break;
                case 2: Console.Write("Ingrese la fecha de finalizaci??n (MM/DD/AAAA). Ingrese 'stop' para abortar.");
                    break;
                case 3: Console.Write("Entrez la date de fin (MM/JJ/AAAA). Entrez 'stop' pour annuler.");
                    break;
                default: Console.Write("Geben Sie das Enddatum ein (MM/TT/JJJJ). Geben Sie 'stop' ein, um abzubrechen.");
                    break;
            }
        }

        public static void PromptBudget()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter Budget. Enter 'stop' to abort.");
                    break;
                case 2: Console.Write("Ingrese el presupuesto. Ingrese 'stop' para abortar.");
                    break;
                case 3: Console.Write("Entrer le budget. Entrez 'stop' pour annuler.");
                    break;
                default: Console.Write("Budget eingeben. Geben Sie 'stop' ein, um abzubrechen.");
                    break;
            }
        }

        public static void DisplayAbortEditMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Editing aborted. Press enter to return to the Vacation Menu.");
                    break;
                case 2: Console.Write("Edici??n abortada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de vacaciones");
                    break;
                case 3: Console.Write("Modification abandonn??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au Menu Vacances");
                    break;
                default: Console.Write("Bearbeitung abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Urlaubsmen?? zur??ckzukehren.");
                    break;
            }
        }

        public static void EditingMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Editing: ");
                    break;
                case 2: Console.WriteLine("Edici??n: ");
                    break;
                case 3: Console.WriteLine("??dition :");
                    break;
                default: Console.WriteLine("Bearbeitung: ");
                    break;
            }
        }

        public static void DeletingMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Deleting: ");
                    break;
                case 2: Console.WriteLine("Eliminando: ");
                    break;
                case 3: Console.WriteLine("Suppression :");
                    break;
                default: Console.WriteLine("L??schen: ");
                    break;
            }
        }

        public static void DeleteVacMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Vacation Deleted. Press enter to return to Vacation Menu");
                    break;
                case 2: Console.Write("Vacaciones eliminadas. ");
                    Console.WriteLine("Presione enter para regresar al men?? de vacaciones.");
                    break;
                case 3: Console.Write("Vacances supprim??es. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au Menu Vacances.");
                    break;
                default: Console.Write("Urlaub gel??scht. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Urlaubsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void AbortVacDeletionMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Deletion aborted. Press enter to return to Vacation Menu");
                    break;
                case 2: Console.Write("Eliminaci??n cancelada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de vacaciones.");
                    break;
                case 3: Console.Write("Suppression annul??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au Menu Vacances.");
                    break;
                default: Console.Write("L??schung abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Urlaubsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void PromptReturnToActMenu()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Press enter to return to Activity Menu");
                    break;
                case 2: Console.WriteLine("Presione enter para regresar al men?? de actividades");
                    break;
                case 3: Console.WriteLine("Appuyez sur Entr??e pour revenir au menu Activit??");
                    break;
                default: Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Aktivit??tsmen?? zur??ckzukehren");
                    break;
            }
            Console.ReadLine();
        }

        public static void PromptActDetails()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter the following details about the new activity.");
                    break;
                case 2: Console.WriteLine("Ingrese los siguientes detalles sobre la nueva actividad.");
                    break;
                case 3: Console.WriteLine("Entrez les d??tails suivants sur la nouvelle activit??.");
                    break;
                default: Console.WriteLine("Geben Sie die folgenden Details zur neuen Aktivit??t ein.");
                    break;
            }
        }

        public static void PromptName()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Name: ");
                    break;
                case 2: Console.WriteLine("Nombre: ");
                    break;
                case 3: Console.WriteLine("Nom: ");
                    break;
                default: Console.WriteLine("Name: ");
                    break;
            }
        }
        //Determine which language to return the category in based on language ID and category selected
        public static string AssignCatLanguage(int catChoice)
        {
            StreamReader inFile = new StreamReader("MenuDisplays/CategoryMenu.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] languageArray = line.Split('#');
                if (int.Parse(languageArray[0]) == Prompts.GetLanguageID())
                {
                    line = inFile.ReadLine();
                    for (int i = 1; i < 10; i++)
                    {
                        if (i == catChoice)
                        {
                            string[] lineArray = line.Split('#');
                            string[] categoryField = lineArray[2].Split(' ');
                            return categoryField[1];
                        }
                        else
                        {
                            line = inFile.ReadLine();
                        }
                    }
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
            return "CAT_NOT_FOUND";
        }

        public static void PromptMinPrice()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Minimum Price: ");
                    break;
                case 2: Console.WriteLine("Precio m??nimo: ");
                    break;
                case 3: Console.WriteLine("Prix ??????minimum: ");
                    break;
                default: Console.WriteLine("Minimaler Preis: ");
                    break;
            }
        }
        public static void PromptMinPriceEdit()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter minimum price. Enter 'stop' to abort.");
                    break;
                case 2: Console.WriteLine("Ingrese el precio m??nimo. Ingrese 'detener' para abortar.");
                    break;
                case 3: Console.WriteLine("Entrez le prix minimum. Entrez ?? stop ?? pour annuler.");
                    break;
                default: Console.WriteLine("Geben Sie den Mindestpreis ein. Geben Sie ???stop??? ein, um abzubrechen.");
                    break;
            }
        }
        public static void PromptMaxPrice()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Maximum Price: ");
                    break;
                case 2: Console.WriteLine("Precio M??ximo: ");
                    break;
                case 3: Console.WriteLine("Prix ??????maximum : ");
                    break;
                default: Console.WriteLine("H??chstpreis: ");
                    break;
            }
        }
        public static void PromptMaxPriceEdit()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter maximum price. Enter 'stop' to abort.");
                    break;
                case 2: Console.WriteLine("Ingrese el precio m??ximo. Ingrese 'detener' para abortar.");
                    break;
                case 3: Console.WriteLine("Entrez le prix maximum. Entrez ?? stop ?? pour annuler.");
                    break;
                default: Console.WriteLine("Geben Sie den H??chstpreis ein. Geben Sie ???stop??? ein, um abzubrechen.");
                    break;
            }
        }

        public static void PromptAmountTime()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("How many?");
                    break;
                case 2: Console.WriteLine("??Cu??ntos?");
                    break;
                case 3: Console.WriteLine("Combien de?");
                    break;
                default: Console.WriteLine("Wie viele?");
                    break;
            }
        }

        public static string AssignMinuteLanguage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: return "Minute";
                case 2: return "Minuto";
                case 3: return "Minute";
                default: return "Minute";
            }
        }

        public static string AssignHourLanguage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: return "Hour";
                case 2: return "Hora";
                case 3: return "Heure";
                default: return "Stunde";
            }
        }

        public static string AssignDayLanguage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: return "Day";
                case 2: return "D??a";
                case 3: return "Jour";
                default: return "Tag";
            }
        }

        public static string AssignYesLanguage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: return "Yes";
                case 2: return "s??";
                case 3: return "Oui";
                default: return "Jawohl";
            }
        }

        public static string AssignNoLanguage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: return "No";
                case 2: return "No";
                case 3: return "Non";
                default: return "Nein";
            }
        }

        public static void PromptForActIDEdit()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please enter the ID of an activity to edit/delete. Enter '-1' to go back.");
                    break;
                case 2: Console.Write("Ingrese el ID de una actividad para editar / eliminar. ");
                    Console.WriteLine("Ingrese '-1' para regresar.");
                    break;
                case 3: Console.Write("Veuillez saisir l'ID d'une activit?? ?? modifier/supprimer. ");
                    Console.WriteLine("Entrez '-1' pour revenir en arri??re.");
                    break;
                default: Console.Write("Bitte geben Sie die ID einer Aktivit??t zum Bearbeiten/L??schen ein. ");
                    Console.WriteLine("Geben Sie '-1' ein, um zur??ckzugehen.");
                    break;
            }
        }

        public static void PromptForCompleteIDEdit()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please enter the ID of a completion to edit. Enter '-1' to go back.");
                    break;
                case 2: Console.Write("Ingrese el ID de una finalizaci??n para editar. ");
                    Console.WriteLine("Ingrese '-1' para regresar.");
                    break;
                case 3: Console.Write("Veuillez saisir l'ID d'une compl??tion ?? modifier. ");
                    Console.WriteLine("Entrez '-1' pour revenir en arri??re.");
                    break;
                default: Console.Write("Bitte geben Sie die ID eines Abschlusses zum Bearbeiten. ");
                    Console.WriteLine("Geben Sie '-1' ein, um zur??ckzugehen.");
                    break;
            }
        }

        public static void PromptForCompleteIDDelete()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please enter the ID of a completion to delete. Enter '-1' to go back.");
                    break;
                case 2: Console.Write("Ingrese el ID de una finalizaci??n para eliminar. ");
                    Console.WriteLine("Ingrese '-1' para regresar.");
                    break;
                case 3: Console.Write("Veuillez saisir l'ID d'une compl??tion ?? effacer. ");
                    Console.WriteLine("Entrez '-1' pour revenir en arri??re.");
                    break;
                default: Console.Write("Bitte geben Sie die ID eines Abschlusses zum l??schen. ");
                    Console.WriteLine("Geben Sie '-1' ein, um zur??ckzugehen.");
                    break;
            }
        }

        public static void PromptForActIDComplete()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Enter the ID of the activity you wish to mark as complete. Enter 'stop' to go back.");
                    break;
                case 2: Console.Write("Ingrese el ID de la actividad que desea marcar como completa. ");
                    Console.WriteLine("Ingrese 'detener' para regresar.");
                    break;
                case 3: Console.Write("Entrez l'ID de l'activit?? que vous souhaitez marquer comme termin??e. ");
                    Console.WriteLine("Entrez ?? stop ?? pour revenir en arri??re.");
                    break;
                default: Console.Write("Geben Sie die ID der Aktivit??t ein, die Sie als abgeschlossen markieren m??chten. ");
                    Console.WriteLine("Geben Sie ???stop??? ein, um zur??ckzugehen.");
                    break;
            }
        }

        public static void PromptDateCompleted()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("When was this activity completed? (MM/DD/YYYY):");
                    break;
                case 2: Console.WriteLine("??Cu??ndo se complet?? esta actividad? (MM/DD/AAAA):");
                    break;
                case 3: Console.WriteLine("Quand cette activit?? a-t-elle ??t?? termin??e? (MM/JJ/AAAA) :");
                    break;
                default: Console.WriteLine("Wann wurde diese Aktivit??t abgeschlossen? (MM/TT/JJJJ):");
                    break;
            }
        }

        public static void PromptExpenditures()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("How much did you spend on this activity?");
                    break;
                case 2: Console.WriteLine("??Cu??nto gastaste en esta actividad?");
                    break;
                case 3: Console.WriteLine("Combien avez-vous d??pens?? pour cette activit?? ?");
                    break;
                default: Console.WriteLine("Wie viel haben Sie f??r diese Aktivit??t ausgegeben?");
                    break;
            }
        }

        public static void PromptReview()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please give a personal review of this activity:");
                    break;
                case 2: Console.WriteLine("Por favor, d?? una rese??a personal de esta actividad:");
                    break;
                case 3: Console.WriteLine("Merci de donner votre avis personnel sur cette activit?? :");
                    break;
                default: Console.WriteLine("Bitte geben Sie eine pers??nliche Bewertung dieser Aktivit??t ab:");
                    break;
            }
        }

        public static void PromptNewDestination()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Destination:");
                    break;
                case 2: Console.WriteLine("Destino:");
                    break;
                case 3: Console.WriteLine("Destination :");
                    break;
                default: Console.WriteLine("Ziel:");
                    break;
            }
        }

        public static void PromptNewStartDate()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Start Date (MM/DD/YYYY):");
                    break;
                case 2: Console.WriteLine("Fecha de inicio (MM/DD/AAAA):");
                    break;
                case 3: Console.WriteLine("Date de d??but (MM/JJ/AAAA) :");
                    break;
                default: Console.WriteLine("Startdatum (MM/TT/JJJJ):");
                    break;
            }
        }

        public static void PromptNewEndDate()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("End Date (MM/DD/YYYY):");
                    break;
                case 2: Console.WriteLine("Fecha de finalizaci??n (MM/DD/AAAA):");
                    break;
                case 3: Console.WriteLine("Date de fin (MM/JJ/AAAA) :");
                    break;
                default: Console.WriteLine("Enddatum (MM/TT/JJJJ):");
                    break;
            }
        }

        public static void PromptNewBudget()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Budget:");
                    break;
                case 2: Console.WriteLine("Presupuesto:");
                    break;
                case 3: Console.WriteLine("Budget :");
                    break;
                default: Console.WriteLine("Budget:");
                    break;
            }
        }

        public static void NewVacationSuccess()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Vacation added successfully!");
                    Console.WriteLine("Press enter to return to Vacation Menu");
                    break;
                case 2: Console.WriteLine("??Vacaciones agregadas con ??xito!");
                    Console.WriteLine("Presione enter para regresar al men?? de vacaciones");
                    break;
                case 3: Console.WriteLine("Vacances ajout??es avec succ??s !");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au Menu Vacances");
                    break;
                default: Console.WriteLine("Urlaub erfolgreich hinzugef??gt!");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Urlaubsmen?? zur??ckzukehren");
                    break;
            }
            Console.ReadLine();
        }

        public static void ActivitiesMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Activities: ");
                    break;
                case 2: Console.WriteLine("Ocupaciones: ");
                    break;
                case 3: Console.WriteLine("Activit??s : ");
                    break;
                default: Console.WriteLine("Aktivit??ten: ");
                    break;
            }
            Console.WriteLine();
        }

        public static void CompletedMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Completed Activities: ");
                    break;
                case 2: Console.WriteLine("Actividades completadas: ");
                    break;
                case 3: Console.WriteLine("Activit??s termin??es : ");
                    break;
                default: Console.WriteLine("Abgeschlossene Aktivit??ten: ");
                    break;
            }
            Console.WriteLine();
        }

        public static void FavoritesMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Favorite Activities: ");
                    break;
                case 2: Console.WriteLine("Actividades favoritas:");
                    break;
                case 3: Console.WriteLine("Activit??s favorites:");
                    break;
                default: Console.WriteLine("Lieblingsaktivit??ten:");
                    break;
            }
            Console.WriteLine();
        }

        public static void IncompleteMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Incomplete Activities: ");
                    break;
                case 2: Console.WriteLine("Actividades incompletas:");
                    break;
                case 3: Console.WriteLine("Activit??s incompl??tes :");
                    break;
                default: Console.WriteLine("Unvollst??ndige Aktivit??ten:");
                    break;
            }
            Console.WriteLine();
        }

        public static void RecommendedMessage()
        {
            Console.Clear();
            if (Recommendations.GetCount() < 1)
            {
                switch(Prompts.GetLanguageID())
                {
                    case 1: Console.WriteLine("You don't have any recommended activities!");
                        break;
                    case 2: Console.WriteLine("??No tienes ninguna actividad recomendada!");
                        break;
                    case 3: Console.WriteLine("Vous n'avez aucune activit?? recommand??e !");
                        break;
                    default: Console.WriteLine("Sie haben keine empfohlenen Aktivit??ten!");
                        break;
                }
            }
            else
            {
                switch(Prompts.GetLanguageID())
                {
                    case 1: Console.WriteLine("Recommended Activities (Price Descending by Category): ");
                        break;
                    case 2: Console.WriteLine("Actividades recomendadas (Precio descendente por categor??a):");
                        break;
                    case 3: Console.WriteLine("Activit??s recommand??es (Prix d??croissant par cat??gorie) :");
                        break;
                    default: Console.WriteLine("Empfohlene Aktivit??ten (Preis absteigend nach Kategorie):");
                        break;
                }
            }
        }

        public static void VacationMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Vacation Details: ");
                    break;
                case 2: Console.WriteLine("Detalles de vacaciones:");
                    break;
                case 3: Console.WriteLine("D??tails des vacances :");
                    break;
                default: Console.WriteLine("Urlaubsdetails:");
                    break;
            }
            Console.WriteLine();
        }

        public static void VacationFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("ID | Destination | Start Date | End Date | Budget");
                    break;
                case 2: Console.WriteLine("ID | Destino | Fecha de inicio | Fecha final | Presupuesto");
                    break;
                case 3: Console.WriteLine("ID | Destination | Date de d??but | Date de fin | Budget");
                    break;
                default: Console.WriteLine("ID | Ziel | Startdatum | Endtermin | Budget");
                    break;
            }
        }

        public static void ActivityFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("ID | Name | Category | Min. Price | Max. Price | Time needed | Tickets necessary");
                    break;
                case 2: Console.WriteLine("ID | Nombre | Categor??a | Min. Precio | Max. Precio | Tiempo necesario | Entradas necesarias");
                    break;
                case 3: Console.WriteLine("ID | Nom | Cat??gorie | Prix Min. | Prix Max. | Temps n??cessaire | Billets n??cessaires");
                    break;
                default: Console.WriteLine("ID | Name | Kategorie | Min. Preis | H??chstpreis | Ben??tigte Zeit | Tickets erforderlich");
                    break;
            }
        }

        public static void CompletionFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("ID | Name | Category | Date Completed | Money Spent | Rating | Recommendation");
                    break;
                case 2: Console.WriteLine("ID | Nombre | Categor??a | Fecha de finalizaci??n | Dinero gastado | Clasificaci??n | Recomendaci??n");
                    break;
                case 3: Console.WriteLine("ID | Nom | Cat??gorie | Rendez-vous complet | Argent d??pens?? | ??valuation | Recommandation");
                    break;
                default: Console.WriteLine("ID | Name | Kategorie | Datum der Fertigstellung | Geld ausgegeben | Bewertung | Empfehlung");
                    break;
            }
        }

        public static void TripSummaryFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Name | Date Completed");
                    break;
                case 2: Console.WriteLine("Nombre | Fecha de finalizaci??n");
                    break;
                case 3: Console.WriteLine("Nom | Rendez-vous complet");
                    break;
                default: Console.WriteLine("Name | Datum der Fertigstellung");
                    break;
            }
        }

        public static void FavoritesFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Name | Rating");
                    break;
                case 2: Console.WriteLine("Nombre | Clasificaci??n");
                    break;
                case 3: Console.WriteLine("Nom | ??valuation");
                    break;
                default: Console.WriteLine("Name | Bewertung");
                    break;
            }
        }

        public static void SpendingAndRecommendFormatHeader()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Name | Rating | Money Spent");
                    break;
                case 2: Console.WriteLine("Nombre | Clasificaci??n | Dinero gastado");
                    break;
                case 3: Console.WriteLine("Nom | ??valuation | Argent d??pens??");
                    break;
                default: Console.WriteLine("Name | Bewertung | Geld ausgegeben");
                    break;
            }
        }

        public static void RemainingMessage()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Remaining Activities: ");
                    break;
                case 2: Console.WriteLine("Actividades restantes:");
                    break;
                case 3: Console.WriteLine("Activit??s restantes :");
                    break;
                default: Console.WriteLine("Verbleibende Aktivit??ten:");
                    break;
            }
            Console.WriteLine();
        }

        public static void SpendingMessage()
        {
            Console.Clear();
            if (Spending.GetCount() < 1)
            {
                switch(Prompts.GetLanguageID())
                {
                    case 1: Console.WriteLine("You don't have any completed activities!");
                        break;
                    case 2: Console.WriteLine("??No tienes ninguna actividad completada!");
                        break;
                    case 3: Console.WriteLine("Vous n'avez aucune activit?? termin??e !");
                        break;
                    default: Console.WriteLine("Sie haben keine abgeschlossenen Aktivit??ten!");
                        break;
                }
            }
            else
            {
                switch(Prompts.GetLanguageID())
                {
                    case 1: Console.WriteLine("Spending Report (Price Descending by Category): ");
                        break;
                    case 2: Console.WriteLine("Informe de gastos (Precio descendente por categor??a): ");
                        break;
                    case 3: Console.WriteLine("Rapport de d??penses (Prix ??????d??croissant par cat??gorie) : ");
                        break;
                    default: Console.WriteLine("Ausgabenbericht (Preis absteigend nach Kategorie): ");
                        break;
                }
            }
            Console.WriteLine();
        }

        public static void EnterToContinueMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Press enter to continue");
                    break;
                case 2: Console.WriteLine("Presione enter para continuar");
                    break;
                case 3: Console.WriteLine("Appuyez sur Entr??e pour continuer");
                    break;
                default: Console.WriteLine("Dr??cken Sie die Eingabetaste, um fortzufahren");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void AbortActDeletionMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Deletion aborted. Press enter to return to Activity Menu");
                    break;
                case 2: Console.Write("Eliminaci??n abortada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de actividades.");
                    break;
                case 3: Console.Write("Suppression annul??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au menu Activit??.");
                    break;
                default: Console.Write("L??schen abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Aktivit??tsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void AbortActEditMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Editing aborted. Press enter to return to Activity Menu");
                    break;
                case 2: Console.Write("Edici??n abortada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de actividades.");
                    break;
                case 3: Console.Write("??dition annul??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au menu Activit??.");
                    break;
                default: Console.Write("Bearbeitung abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Aktivit??tsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void AbortCompletionEditMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Editing aborted. Press enter to return to Completion Menu");
                    break;
                case 2: Console.Write("Edici??n abortada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de finalizaci??n.");
                    break;
                case 3: Console.Write("??dition annul??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au menu d'ach??vement.");
                    break;
                default: Console.Write("Bearbeitung abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Abschlussmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void AbortCompletionDeletionMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Deletion aborted. Press enter to return to Completion Menu");
                    break;
                case 2: Console.Write("Eliminaci??n abortada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de finalizaci??n.");
                    break;
                case 3: Console.Write("Suppression annul??e. ");
                    Console.WriteLine("Appuyez sur entr??e pour revenir au menu de fin.");
                    break;
                default: Console.Write("L??schen abgebrochen. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Abschlussmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void DeleteActMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Activity Deleted. Press enter to return to Activity Menu");
                    break;
                case 2: Console.Write("Actividad eliminada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de actividades.");
                    break;
                case 3: Console.Write("Activit?? supprim??e. ");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au menu Activit??.");
                    break;
                default: Console.Write("Aktivit??t gel??scht. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Aktivit??tsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void DeleteCompletionMessage()
        {
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Completion Deleted. Press enter to return to Completion Menu");
                    break;
                case 2: Console.Write("Finalizaci??n eliminada. ");
                    Console.WriteLine("Presione enter para regresar al men?? de finalizaci??n.");
                    break;
                case 3: Console.Write("Ach??vement supprim??. ");
                    Console.WriteLine("Appuyez sur entr??e pour revenir au menu de fin.");
                    break;
                default: Console.Write("Abschluss gel??scht. ");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Abschlussmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
        }

        public static void PromptNoActivities()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any activities!");
                    break;
                case 2: Console.WriteLine("??No tienes ninguna actividad! ");
                    break;
                case 3: Console.WriteLine("Vous n'avez aucune activit?? ! ");
                    break;
                default: Console.WriteLine("Sie haben keine Aktivit??ten! ");
                    break;
            }
        }

        public static void PromptNeedVacation()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Please add a vacation before adding activities.");
                    break;
                case 2: Console.WriteLine("Agregue unas vacaciones antes de agregar actividades.");
                    break;
                case 3: Console.WriteLine("Veuillez ajouter des vacances avant d'ajouter des activit??s.");
                    break;
                default: Console.WriteLine("Bitte f??gen Sie einen Urlaub hinzu, bevor Sie Aktivit??ten hinzuf??gen.");
                    break;
            }
            MainMenuPrompt();
        }

        public static void PromptCantComplete()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Error: No vacation found.");
                    Console.WriteLine("Please create a vacation to complete activities.");
                    break;
                case 2: Console.WriteLine("Error: no se encontraron vacaciones.");
                    Console.WriteLine("Cree unas vacaciones para completar las actividades.");
                    break;
                case 3: Console.WriteLine("Erreur : Aucun cong?? trouv??.");
                    Console.WriteLine("Veuillez cr??er des vacances pour terminer les activit??s.");
                    break;
                default: Console.WriteLine("Fehler: Kein Urlaub gefunden.");
                    Console.WriteLine("Bitte erstellen Sie einen Urlaub, um Aktivit??ten abzuschlie??en.");
                    break;
            }
        }

        public static void PromptNoVacations()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any vacations!");
                    Console.WriteLine("Press enter to return to Vacation Menu.");
                    break;
                case 2: Console.Write("??No tienes vacaciones!");
                    Console.WriteLine("Presione enter para regresar al men?? de vacaciones.");
                    break;
                case 3: Console.Write("Vous n'avez pas de vacances !");
                    Console.WriteLine("Appuyez sur Entr??e pour revenir au Menu Vacances.");
                    break;
                default: Console.Write("Sie haben keine Ferien!");
                    Console.WriteLine("Dr??cken Sie die Eingabetaste, um zum Urlaubsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }

        public static void PromptCantAddVacation()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Only one vacation may be recorded at a time.");
                    Console.WriteLine("Please edit or delete the current vacation.");
                    break;
                case 2: Console.Write("Error: solo se puede registrar una vacaci??n a la vez.");
                    Console.WriteLine("Edite o elimine las vacaciones actuales.");
                    break;
                case 3: Console.Write("Erreur : Un seul cong?? peut ??tre enregistr?? ?? la fois.");
                    Console.WriteLine("Veuillez modifier ou supprimer les vacances en cours.");
                    break;
                default: Console.Write("Fehler: Es kann immer nur ein Urlaub gleichzeitig aufgezeichnet werden.");
                    Console.WriteLine("Bitte bearbeiten oder l??schen Sie den aktuellen Urlaub.");
                    break;
            }
            Console.ReadLine();
        }
        //Displays the completion date error in the current language
        public static void PromptCompleteDateError(string vacationStart, string vacationEnd)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Completion date must be within the vacation dates.");
                    Console.WriteLine($"Your vacation date range: {vacationStart}-{vacationEnd}");
                    Console.WriteLine("Please enter a valid completion date (MM/DD/YYYY):");
                    break;
                case 2: Console.WriteLine("Error: la fecha de finalizaci??n debe estar dentro de las fechas de vacaciones.");
                    Console.WriteLine($"Su intervalo de fechas de vacaciones: {vacationStart}-{vacationEnd}");
                    Console.WriteLine("Ingrese una fecha de finalizaci??n v??lida (MM/DD/AAAA):");
                    break;
                case 3: Console.WriteLine("Erreur : La date d'ach??vement doit ??tre comprise entre les dates de vacances.");
                    Console.WriteLine($"Votre plage de dates de vacances : {vacationStart}-{vacationEnd}");
                    Console.WriteLine("Veuillez entrer une date d'ach??vement valide (MM/JJ/AAAA):");
                    break;
                default: Console.WriteLine("Fehler: Das Fertigstellungsdatum muss innerhalb der Urlaubsdaten liegen.");
                    Console.WriteLine($"Ihr Urlaubsdatumsbereich: {vacationStart}-{vacationEnd}");
                    Console.WriteLine("Bitte geben Sie ein g??ltiges Abschlussdatum ein (MM/TT/JJJJ):");
                    break;
            }
            Console.ResetColor();
        }
        //Returns a general date error based on the specific error incurred and the current language 
        public static void PromptDateError(int index, int dateType)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(Prompts.GetLanguageID())
            {
                case 1: if (dateType < 0)
                        {
                            switch (index)
                            {
                                case 1: Console.Write("Error: Invalid month. ");
                                    break;
                                case 2: Console.Write("Error: Invalid day. ");
                                    break;
                                case 3: Console.Write("Error: Invalid year. Please use 1999-2099. ");
                                    break;
                                default: Console.Write("Error: Invalid date. ");
                                    break;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 1: Console.WriteLine("Error: End month cannot be before start month. ");
                                    break;
                                case 2: Console.WriteLine("Error: End day cannot be before start day. ");
                                    break;
                                default: Console.WriteLine("Error: End year cannot be before start year. ");
                                    break;
                            }
                        }
                        Console.WriteLine("Please enter a valid date (MM/DD/YYYY): ");
                    break;
                case 2: if (dateType < 0)
                        {
                            switch (index)
                            {
                                case 1: Console.Write("Error: mes inv??lido. ");
                                    break;
                                case 2: Console.Write("Error: d??a no v??lido. ");
                                    break;
                                case 3: Console.Write("Error: a??o no v??lido. Utilice 1999-2099. ");
                                    break;
                                default: Console.Write("Error: fecha inv??lida. ");
                                    break;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 1: Console.WriteLine("Error: el mes de finalizaci??n no puede ser anterior al mes de inicio. ");
                                    break;
                                case 2: Console.WriteLine("Error: el d??a de finalizaci??n no puede ser anterior al d??a de inicio. ");
                                    break;
                                default: Console.WriteLine("Error: el a??o de finalizaci??n no puede ser anterior al a??o de inicio. ");
                                    break;
                            }
                        }
                        Console.WriteLine("Por favor introduzca una fecha valida (MM/DD/AAAA): ");
                    break;
                case 3: if (dateType < 0)
                        {
                            switch (index)
                            {
                                case 1: Console.Write("Erreur : mois non valide. ");
                                    break;
                                case 2: Console.Write("Erreur : jour non valide. ");
                                    break;
                                case 3: Console.Write("Erreur : ann??e non valide. Veuillez utiliser 1999-2099. ");
                                    break;
                                default: Console.Write("Erreur : date invalide. ");
                                    break;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 1: Console.WriteLine("Erreur : Le mois de fin ne peut pas ??tre ant??rieur au mois de d??but. ");
                                    break;
                                case 2: Console.WriteLine("Erreur : le jour de fin ne peut pas ??tre ant??rieur au jour de d??but. ");
                                    break;
                                default: Console.WriteLine("Erreur : L'ann??e de fin ne peut pas ??tre ant??rieure ?? l'ann??e de d??but. ");
                                    break;
                            }
                        }
                        Console.WriteLine("Veuillez entrer une date valide (MM/JJ/AAAA): ");
                    break;
                default: if (dateType < 0)
                        {
                            switch (index)
                            {
                                case 1: Console.Write("Fehler: Ung??ltiger Monat. ");
                                    break;
                                case 2: Console.Write("Fehler: Ung??ltiger Tag. ");
                                    break;
                                case 3: Console.Write("Fehler: Ung??ltiges Jahr. Bitte verwenden Sie 1999-2099. ");
                                    break;
                                default: Console.Write("Fehler: Ung??ltiges Datum. ");
                                    break;
                            }
                        }
                        else
                        {
                            switch (index)
                            {
                                case 1: Console.WriteLine("Fehler: Der Endmonat darf nicht vor dem Startmonat liegen. ");
                                    break;
                                case 2: Console.WriteLine("Fehler: Der Endtag darf nicht vor dem Starttag liegen. ");
                                    break;
                                default: Console.WriteLine("Fehler: Das Endjahr darf nicht vor dem Startjahr liegen. ");
                                    break;
                            }
                        }
                        Console.WriteLine("Bitte gib ein korrektes Datum an (MM/TT/JJJJ): ");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptNoRemaining()
        {
            Console.Clear();
            switch(Prompts.GetLanguageID())
            {
                case 1: Console.WriteLine("You don't have any activities remaining!");
                    break;
                case 2: Console.WriteLine("??No te quedan actividades!");
                    break;
                case 3: Console.WriteLine("Vous n'avez plus d'activit??s !");
                    break;
                default: Console.WriteLine("Sie haben keine Aktivit??ten mehr!");
                    break;
            }
        }

        public static void PromptAbortCompletion()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Completion process aborted.");
                    break;
                case 2: Console.WriteLine("Proceso de finalizaci??n abortado.");
                    break;
                case 3: Console.WriteLine("Processus d'ach??vement interrompu.");
                    break;
                default: Console.WriteLine("Abschlussprozess abgebrochen.");
                    break;
            }
        }

        public static void PromptProcessedCompletion()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Completion processed successfully!");
                    break;
                case 2: Console.WriteLine("??Finalizaci??n procesada con ??xito!");
                    break;
                case 3: Console.WriteLine("Ach??vement trait?? avec succ??s !");
                    break;
                default: Console.WriteLine("Abschluss erfolgreich verarbeitet!");
                    break;
            }
        }

        public static void PromptEnterName()
        {
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Enter Name. Enter 'stop' to abort.");
                    break;
                case 2: Console.WriteLine("Ingrese su nombre. Ingrese 'detener' para abortar.");
                    break;
                case 3: Console.WriteLine("Entrez le nom. Entrez ?? stop ?? pour annuler.");
                    break;
                default: Console.WriteLine("Name eingeben. Geben Sie ???stop??? ein, um abzubrechen.");
                    break;
            }
        }
        //Returns a destination placeholder in the current language
        public static string GetPlaceholderDestination()
        {
            switch(GetLanguageID())
            {
                case 1: return "[No Destination]";
                case 2: return "[Sin destino]";
                case 3: return "[Aucune destination]";
                default: return "[Kein Ziel]";
            }
        }
        //Return a review placeholder in the current lanugage
        public static string GetPlaceHolderReview()
        {
            switch(GetLanguageID())
            {
                case 1: return "[No Review]";
                case 2: return "[Sin revisi??n]";
                case 3: return "[Pas d'examen]";
                default: return "[Keine Rezension]";
            }
        }

        public static void PromptValidInt()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid integer.");
                    break;
                case 2: Console.WriteLine("Error: ingrese un n??mero entero v??lido.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un nombre entier valide.");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie eine g??ltige Ganzzahl ein.");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidBudget()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid budget (Non-negative):");
                    break;
                case 2: Console.WriteLine("Error: ingrese un presupuesto v??lido (no negativo):");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un budget valide (Non n??gatif) :");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie ein g??ltiges Budget ein (nicht negativ):");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidSpent()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid amount spent (Non-negative):");
                    break;
                case 2: Console.WriteLine("Error: ingrese una cantidad v??lida gastada (no negativa):");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un montant valide d??pens?? (Non n??gatif) :");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie einen g??ltigen ausgegebenen Betrag ein (nicht negativ):");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidMaxPrice()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Maximum price cannot be lower than minimum price.");
                    Console.WriteLine("Please enter a valid maximum price: ");
                    break;
                case 2: Console.WriteLine("Error: el precio m??ximo no puede ser inferior al precio m??nimo.");
                    Console.WriteLine("Introduzca un precio m??ximo v??lido: ");
                    break;
                case 3: Console.WriteLine("Erreur : Le prix maximum ne peut pas ??tre inf??rieur au prix minimum.");
                    Console.WriteLine("Veuillez saisir un prix maximum valide : ");
                    break;
                default: Console.WriteLine("Fehler: Der H??chstpreis kann nicht unter dem Mindestpreis liegen.");
                    Console.WriteLine("Bitte geben Sie einen g??ltigen H??chstpreis ein: ");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PromptValidMinPrice()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Minimum price cannot be higher than maximum price.");
                    Console.WriteLine("Please enter a valid minimum price: ");
                    break;
                case 2: Console.WriteLine("Error: el precio m??nimo no puede ser superior al precio m??ximo.");
                    Console.WriteLine("Introduzca un precio m??nimo v??lido: ");
                    break;
                case 3: Console.WriteLine("Erreur : Le prix minimum ne peut pas ??tre sup??rieur au prix maximum.");
                    Console.WriteLine("Veuillez saisir un prix minimum valide : ");
                    break;
                default: Console.WriteLine("Fehler: Der Mindestpreis kann nicht h??her sein als der H??chstpreis.");
                    Console.WriteLine("Bitte geben Sie einen g??ltigen Mindestpreis ein: ");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PromptValidOption()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 2: Console.WriteLine("Error: seleccione una opci??n v??lida.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez s??lectionner une option valide.");
                    break;
                case 4: Console.WriteLine("Fehler: Bitte w??hlen Sie eine g??ltige Option aus.");
                    break;
                default: Console.WriteLine("Error: Please select a valid option.");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidID()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid ID or 'stop' to return to Main Menu.");
                    break;
                case 2: Console.WriteLine("Error: ingrese una ID v??lida o 'detener' para regresar al men?? principal.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un identifiant valide ou ?? stop ?? pour revenir au menu principal.");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie eine g??ltige ID oder ???stop??? ein, um zum Hauptmen?? zur??ckzukehren.");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidEditID()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid ID.");
                    Console.WriteLine("Enter 'stop' to return to Activity Menu.");
                    break;
                case 2: Console.WriteLine("Error: ingrese una identificaci??n v??lida.");
                    Console.WriteLine("Ingrese 'stop' para regresar al Men?? de actividades.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un identifiant valide.");
                    Console.WriteLine("Entrez ?? stop ?? pour revenir au menu Activit??.");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie eine g??ltige ID ein.");
                    Console.WriteLine("Geben Sie ???stop??? ein, um zum Aktivit??tsmen?? zur??ckzukehren.");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidOrAbort()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid ID.");
                    Console.WriteLine("Enter '-1' to abort editing.");
                    break;
                case 2: Console.WriteLine("Error: ingrese una identificaci??n v??lida.");
                    Console.WriteLine("Ingrese '-1' para cancelar la edici??n.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un identifiant valide.");
                    Console.WriteLine("Entrez '-1' pour annuler l'??dition.");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie eine g??ltige ID ein.");
                    Console.WriteLine("Geben Sie '-1' ein, um die Bearbeitung abzubrechen.");
                    break;
            }
            Console.ResetColor();
        }

        public static void PromptValidIDNoExit()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Error: Please enter a valid ID.");
                    break;
                case 2: Console.WriteLine("Error: ingrese una identificaci??n v??lida.");
                    break;
                case 3: Console.WriteLine("Erreur : Veuillez saisir un identifiant valide.");
                    break;
                default: Console.WriteLine("Fehler: Bitte geben Sie eine g??ltige ID ein.");
                    break;
            }
            Console.ResetColor();
        }
        //Determine which language to return the rating in based on language ID and rating selected
        public static string AssignRating(int ratingChoice)
        {
            StreamReader inFile = new StreamReader("MenuDisplays/ProcessRating.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] languageArray = line.Split('#');
                if (int.Parse(languageArray[0]) == Prompts.GetLanguageID())
                {
                    line = inFile.ReadLine();
                    for (int i = 1; i < 6; i++)
                    {
                        if (i == ratingChoice)
                        {
                            string[] lineArray = line.Split('#');
                            string[] ratingField = lineArray[2].Split(' ');
                            return (ratingField[1] + " " + ratingField[2]);
                        }
                        else
                        {
                            line = inFile.ReadLine();
                        }
                    }
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
            return "RATING_NOT_FOUND";
        }
        //Determine which language to return the recommend status in based on language ID and status selected
        public static string AssignRecommend(int recommendChoice)
        {
            StreamReader inFile = new StreamReader("MenuDisplays/ProcessRecommend.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] languageArray = line.Split('#');
                if (int.Parse(languageArray[0]) == Prompts.GetLanguageID())
                {
                    line = inFile.ReadLine();
                    for (int i = 1; i < 3; i++)
                    {
                        if (i == recommendChoice)
                        {
                            string[] lineArray = line.Split('#');
                            string[] recommendField = lineArray[2].Split(' ');
                            return recommendField[1];
                        }
                        else
                        {
                            line = inFile.ReadLine();
                        }
                    }
                }
                line = inFile.ReadLine();
                
            }
            inFile.Close();
            return "RECOMMENDATION_NOT_FOUND";
        }

        public static void ThankUser()
        {
            Console.Clear();
            switch(GetLanguageID())
            {
                case 1: Console.WriteLine("Thanks for using our vacation advising system!");
                    break;
                case 2: Console.WriteLine("??Gracias por utilizar nuestro sistema de asesoramiento vacacional!");
                    break;
                case 3: Console.WriteLine("Merci d'avoir utilis?? notre syst??me de conseil en vacances !");
                    break;
                default: Console.WriteLine("Vielen Dank, dass Sie unser Urlaubsberatungssystem nutzen!");
                    break;
            }
        }
    }
}