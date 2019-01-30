using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewExemplo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public ObservableCollection<Game> Games { get; }

        private int _rating;
        public int Rating
        {
            get { return _rating; }
            set => SetProperty(ref _rating, value);
        }

        public MainViewModel()
        {
            Games = new ObservableCollection<Game>();

            Games.Add(new Game
            {
                Nome = "God of War",
                TituloBR = "O bom da guerra"
            });

            Games.Add(new Game
            {
                Nome = "The last of us",
                TituloBR = "Nois que sobramus"
            });

            Games.Add(new Game
            {
                Nome = "Mario Kart 8",
                TituloBR = "Correndo com meus Amig..Inimigos"
            });

            Games.Add(new Game
            {
                Nome = "Super Mario Odyssey",
                TituloBR = "As viagens do Bigode"
            });

            Games.Add(new Game
            {
                Nome = "Halo",
                TituloBR = "E eu passei metiolate"
            });

        }

    }
}
