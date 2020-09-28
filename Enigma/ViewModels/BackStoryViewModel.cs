using Enigma.Models;
using Enigma.Models.Repositories;
using Enigma.ViewModels.Base;
using Enigma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Enigma.ViewModels
{
    public class BackStoryViewModel : BaseViewModel
    {
        public string BackStoryText { get; set; }
        public ICommand GoToPageCommand { get; set; }


        public BackStoryViewModel(Player player)
        {
            MyPlayer = new Player();
            MyPlayer = player;

            ListOfSuspects = SetSuspectsForGame();
            SetKiller(ListOfSuspects);
            EncryptKillerName(ListOfSuspects);

            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
        }

        public BackStoryViewModel()
        {
            GoToPageCommand = new RelayCommand(GoToPuzzlePage);
            BackStoryText = $"The president of Russia has assigned {MyPlayer.Player_name} to solve the mysterious murder of his wife Katja. \nThe police has no suspects and are totally perplexed. \nThe only clue at your disposal" +
                " is a series of puzzles found at the crime scene. \nIf the puzzle is too challenging you have the option to display a hint which could help you in solving the puzzle, this will however add 60 seconds to your time. \n\n\n\t\tWill You be the player who finds the killer the fastest?";
        }


        private ObservableCollection<Suspect> GetAllSuspects()
        {
            ObservableCollection<Suspect> Templist = new ObservableCollection<Suspect>();
            foreach (var suspect in Repository.GetAllSuspects())
            {
                Templist.Add(suspect);
            }
            return Templist;
        }

        private ObservableCollection<Suspect> SetSuspectsForGame(int number = 4)
        {
            ObservableCollection<Suspect> ListOfAllSuspects = new ObservableCollection<Suspect>();
            ListOfAllSuspects = GetAllSuspects();
            ObservableCollection<Suspect> SuspectsInGame = new ObservableCollection<Suspect>();

            int position;
            Random random = new Random();
            for (int i = 0; i < number; i++)
            {
                position = random.Next(ListOfAllSuspects.Count);
                if (SuspectsInGame.Contains(ListOfAllSuspects[position]))
                {
                    i = i - 1;
                }
                else
                {
                    SuspectsInGame.Add(ListOfAllSuspects[position]);
                }
            }
            return SuspectsInGame;
        }

        private void SetKiller(ObservableCollection<Suspect> suspects)
        {
            Random random = new Random();
            int index;
            index = random.Next(suspects.Count);
            suspects[index].IsKiller = true;
        }

        public void EncryptKillerName(ObservableCollection<Suspect> listOfSuspects)
        {
            string killerName = "";
            for (int suspect = 0; suspect < listOfSuspects.Count; suspect++)
            {
                if (listOfSuspects[suspect].IsKiller)
                {
                    killerName = listOfSuspects[suspect].Name;
                    listOfSuspects[suspect].EncryptedName = new char[listOfSuspects[suspect].Name.Length];
                    foreach (KeyValuePair<string, string> pair in SymbolAlphabet.TranslateMySymbolsToLetters)
                    {
                        killerName = killerName.ToLower().Replace(pair.Value, pair.Key);
                    }

                    for (int i = 0; i < killerName.Length; i++)
                    {
                        foreach (char c in killerName)
                        {
                            listOfSuspects[suspect].EncryptedName[i] = c;
                            i++;
                        }
                    }
                }
            }
        }

        public void GoToPuzzlePage()
        {
         var model = new PuzzlePageViewModel();
         var page = new PuzzlePage(model);
         NavigationService.Navigate(page);
        }
    }
}
