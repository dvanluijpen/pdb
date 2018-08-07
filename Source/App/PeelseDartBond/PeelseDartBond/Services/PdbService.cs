using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PeelseDartBond.DependencyServices;
using PeelseDartBond.Helpers;
using PeelseDartBond.Model;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Model.Exceptions;
using PeelseDartBond.Utilities;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PeelseDartBond.Services
{
    public class PdbService : RestService
    {
        #region Instance

        static PdbService _instance;
        public static PdbService Instance
        {
            get
            {
                if (_instance == null) _instance = new PdbService();
                return _instance;
            }
        }

        #endregion Instance


        #region Fields

        Model.Entities.Competition _selectedCompetition;
        Model.Entities.CompetitionYear _selectedCompetitionYear;

        List<Model.Entities.News> _news;
        List<Model.Entities.Competition> _competitions;
        List<Model.Entities.CompetitionYear> _competitionYears;
        List<Model.Entities.Ranking> _rankings;
        List<Model.Entities.Schedule> _schedule;
        List<Model.Entities.WeekResult> _results;
        List<Model.Entities.MatrixRow> _matrix;
        List<Model.Entities.Player180s> _player180s;
        List<Model.Entities.PlayerRanking> _playerRankings;
        List<Model.Entities.PlayerFinish> _playerFinishes;

        #endregion Fields


        #region Constructors & Initialization

        public PdbService()
        {
            InitializeProperties();
            WireEvents();
        }

        private void InitializeProperties()
        {
            _selectedCompetition = new Model.Entities.Competition();
            _selectedCompetitionYear = new Model.Entities.CompetitionYear();

            _news = new List<Model.Entities.News>();
            _competitions = new List<Model.Entities.Competition>();
            _competitionYears = new List<Model.Entities.CompetitionYear>();
            _rankings = new List<Model.Entities.Ranking>();
            _schedule = new List<Model.Entities.Schedule>();
            _results = new List<Model.Entities.WeekResult>();
            _matrix = new List<Model.Entities.MatrixRow>();
            _player180s = new List<Model.Entities.Player180s>();
            _playerRankings = new List<Model.Entities.PlayerRanking>();
            _playerFinishes = new List<Model.Entities.PlayerFinish>();
        }

        private void WireEvents()
        {
            SelectedCompetitionChanged -= OnCompetitionChanged;
            SelectedCompetitionChanged += OnCompetitionChanged;

            SelectedCompetitionYearChanged -= OnCompetitionYearChanged;
            SelectedCompetitionYearChanged += OnCompetitionYearChanged;
        }

        public void Initialize()
        {
            Task.Run(async () => await GetCompetitionYears());
        }

        #endregion Constructors & Initialization


        #region Events

        public static event EventHandler<CompetitionEventArgs> SelectedCompetitionChanged;
        public static event EventHandler<CompetitionYearEventArgs> SelectedCompetitionYearChanged;
        public static event EventHandler<NewsEventArgs> NewsLoaded;
        public static event EventHandler CompetitionsLoaded;
        public static event EventHandler<CompetitionYearsEventArgs> CompetitionYearsLoaded;
        public static event EventHandler<RankingEventArgs> RankingsLoaded;
        public static event EventHandler<ScheduleEventArgs> ScheduleLoaded;
        public static event EventHandler<ResultsEventArgs> ResultsLoaded;
        public static event EventHandler<MatrixEventArgs> MatrixLoaded;
        public static event EventHandler<Player180sEventArgs> Player180sLoaded;
        public static event EventHandler<PlayerRankingsEventArgs> PlayerRankingsLoaded;
        public static event EventHandler<PlayerFinishesEventArgs> PlayerFinishesLoaded;

        #endregion Events


        #region Properties

        public Model.Entities.Competition SelectedCompetition
        {
            get { return _selectedCompetition; }
            set 
            { 
                if (value.IsNullOrEmpty() || _selectedCompetition == value)
                    return;
                
                _selectedCompetition = value; 
                SelectedCompetitionChanged?.Invoke(null, new CompetitionEventArgs(value)); }
        }

        public Model.Entities.CompetitionYear SelectedCompetitionYear
        {
            get { return _selectedCompetitionYear; }
            set { _selectedCompetitionYear = value; SelectedCompetitionYearChanged?.Invoke(null, new CompetitionYearEventArgs(value)); }
        }

        public List<Model.Entities.News> News
        {
            get { return _news; }
            set { _news = value; NewsLoaded?.Invoke(null, new NewsEventArgs(value)); }
        }

        public List<Model.Entities.Competition> Competitions
        {
            get { return _competitions; }
            set { _competitions = value; CompetitionsLoaded?.Invoke(null, EventArgs.Empty); }
        }

        public List<Model.Entities.CompetitionYear> CompetitionYears
        {
            get { return _competitionYears; }
            set { _competitionYears = value; CompetitionYearsLoaded?.Invoke(null, new CompetitionYearsEventArgs(value)); }
        }

        public List<Model.Entities.Ranking> Rankings
        {
            get { return _rankings; }
            set { _rankings = value; RankingsLoaded?.Invoke(null, new RankingEventArgs(value)); }
        }

        public List<Model.Entities.Schedule> Schedule
        {
            get { return _schedule; }
            set { _schedule = value; ScheduleLoaded?.Invoke(null, new ScheduleEventArgs(value)); }
        }

        public List<Model.Entities.WeekResult> Results
        {
            get { return _results; }
            set { _results = value; ResultsLoaded?.Invoke(null, new ResultsEventArgs(value)); }
        }

        public List<Model.Entities.MatrixRow> Matrix
        {
            get { return _matrix; }
            set { _matrix = value; MatrixLoaded?.Invoke(null, new MatrixEventArgs(value)); }
        }

        public List<Model.Entities.Player180s> Player180s
        {
            get { return _player180s; }
            set { _player180s = value; Player180sLoaded?.Invoke(null, new Player180sEventArgs(value)); }
        }

        public List<Model.Entities.PlayerRanking> PlayerRankings
        {
            get { return _playerRankings; }
            set { _playerRankings = value; PlayerRankingsLoaded?.Invoke(null, new PlayerRankingsEventArgs(value)); }
        }

        public List<Model.Entities.PlayerFinish> PlayerFinishes
        {
            get { return _playerFinishes; }
            set { _playerFinishes = value; PlayerFinishesLoaded?.Invoke(null, new PlayerFinishesEventArgs(value)); }
        }

        #endregion Properties


        #region Event Handlers

        void OnCompetitionYearChanged(object sender, CompetitionYearEventArgs e)
        {
            Competitions = e.CompetitionYear.Competitions;
        }

        async void OnCompetitionChanged(object sender, CompetitionEventArgs e)
        {
            ConnectivityHelper.CheckForInternetAccess();

            await GetRankings();
            await GetSchedule();
            await GetResults();
            await GetMatrix();
            await GetPlayer180s();
            //await GetPlayerRankings();
            await GetPlayerFinishes();
        }

        #endregion Event Handlers


        #region Methods

        public async Task GetNews()
        {
            ConnectivityHelper.CheckForInternetAccess();

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.News>>(Constants.Urls.News);
            News = result.ToList().Flatten();
        }

        public async Task GetCompetitionYears()
        {
            ConnectivityHelper.CheckForInternetAccess();

            var competitionYears = new List<Model.Entities.CompetitionYear>();
            var year = 13;
            var caughtException = false;

            while (!caughtException)
            {
                try
                {
                    var title = $"20{year}-20{year + 1}";
                    var url = $"http://pdbdarts.nl/seizoen/{year}{year + 1}/competitie.json";
                    var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.Competition>>(url);
                    competitionYears.Add(new Model.Entities.CompetitionYear
                    {
                        Url = url,
                        Title = title,
                        Competitions = result.ToList().Flatten()
                    });
                    year += 1;
                }
                catch
                {
                    caughtException = true;
                }
            }

            CompetitionYears = competitionYears.OrderByDescending(y => y.Title).ToList();
            SelectedCompetitionYear = CompetitionYears.FirstOrDefault();

        }

        public async Task GetCompetitions(string url)
        {
            ConnectivityHelper.CheckForInternetAccess();

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.Competition>>(url);
            Competitions = result.ToList().Flatten();
        }

        public async Task GetRankings()
        {
            if (SelectedCompetition?.Rankings == null)
                return;

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.Ranking>>(SelectedCompetition.Rankings);
            Rankings = result.ToList().Flatten();
        }

        public async Task GetSchedule()
        {
            if (SelectedCompetition?.Schedule == null)
                return;

            var results = await PerformAndDeserializeRequestAsync<IEnumerable<Model.Entities.Schedule>>(SelectedCompetition.Schedule);
            Schedule = results.ToList();
        }

        public async Task GetResults()
        {
            if (SelectedCompetition?.Results == null)
                return;
            
            var results = await PerformAndDeserializeRequestAsync<IEnumerable<Model.Entities.WeekResult>>(SelectedCompetition.Results);
            Results = results.ToList();
        }

        public async Task GetMatrix()
        {
            if (SelectedCompetition?.Matrix == null)
                return;

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.MatrixRow>>(SelectedCompetition.Matrix);
            Matrix = result.ToList().Flatten();
        }

        public async Task GetPlayer180s()
        {
            if (SelectedCompetition?.Player180s == null)
                return;

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.Player180s>>(SelectedCompetition.Player180s);
            Player180s = result.ToList().Flatten();
        }

        public async Task GetPlayerRankings()
        {
            if (SelectedCompetition?.PlayerRankings == null)
                return;

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.PlayerRankings>>(SelectedCompetition.PlayerRankings);
            PlayerRankings = result.ToList().Flatten();
        }

        public async Task GetPlayerFinishes()
        {
            if (SelectedCompetition?.PlayerFinishes == null)
                return;

            var result = await PerformAndDeserializeRequestAsync<IEnumerable<Model.DataTransferObjects.PlayerFinishes>>(SelectedCompetition.PlayerFinishes);
            PlayerFinishes = result.ToList().Flatten();
        }

        #endregion Methods
    }
}
