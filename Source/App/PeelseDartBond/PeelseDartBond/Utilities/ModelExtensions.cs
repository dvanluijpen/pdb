using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeelseDartBond.Utilities
{
    public static class ModelExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return true;

            return !source.Any();
        }

        public static bool IsNullOrEmpty(this Model.Entities.Competition source)
        {
            if (source == null)
                return true;

            return string.IsNullOrWhiteSpace(source.Name);
        }

        public static List<Model.Entities.News> Flatten(this List<Model.DataTransferObjects.News> dataTransferObjects)
        {
            var entities = new List<Model.Entities.News>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.News
                {
                    Title = dataTransferObject.Title,
                    Text = dataTransferObject.Text,
                    Date = dataTransferObject.Date,
                });
            }

            return entities;
        }

        public static List<Model.Entities.Competition> Flatten(this List<Model.DataTransferObjects.Competition> dataTransferObjects)
        {
            var entities = new List<Model.Entities.Competition>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.Competition
                {
                    Name = dataTransferObject.Division,
                    Rankings = dataTransferObject.Ranking,
                    Results = dataTransferObject.Results,
                    PlayerRankings = dataTransferObject.Singles,
                    Matrix = dataTransferObject.Matrix,
                    Player180s = dataTransferObject.OneHundredAndEighties,
                    PlayerFinishes = dataTransferObject.Finishes,
                    Schedule = dataTransferObject.Schedule,
                });
            }

            return entities;
        }

        public static List<Model.Entities.Ranking> Flatten(this List<Model.DataTransferObjects.Ranking> dataTransferObjects)
        {
            var entities = new List<Model.Entities.Ranking>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.Ranking
                {
                    Position = dataTransferObject.Position,
                    Team = dataTransferObject.Team,
                    TeamUrl = dataTransferObject.TeamUrl,
                    Played = dataTransferObject.Played,
                    Won = dataTransferObject.Won,
                    Draw = dataTransferObject.Draw,
                    Lost = dataTransferObject.Lost,
                    Points = dataTransferObject.Points,
                    Penalties = dataTransferObject.Penalties,
                    MatchPoints = dataTransferObject.MatchPoints,
                    AveragePoints = dataTransferObject.AveragePoints,
                    Status = dataTransferObject.Status,
                });
            }

            return entities;
        }

        public static Model.Entities.Schedule FlattenSchedule(this Dictionary<string, object> dataTransferObject)
        {
            var mdString = dataTransferObject["match_day"].ToString();
            var mdYear = Convert.ToInt32(mdString.Substring(0, 4));
            var mdMonth = Convert.ToInt32(mdString.Substring(5, 2));
            var mdDay = Convert.ToInt32(mdString.Substring(8, 2));
            var matchDate = new DateTime(mdYear, mdMonth, mdDay);

            var entity = new Model.Entities.Schedule
            {
                MatchDay = matchDate.DayOfWeek.ToString(),
                MatchDate = matchDate,
                Week = Convert.ToInt32(dataTransferObject["weeknumber"]),
                TeamHome = dataTransferObject["home_team"].ToString(),
                TeamHomeUrl = dataTransferObject["home_team_url"].ToString(),
                TeamAway = dataTransferObject["out_team"].ToString(),
                TeamAwayUrl = dataTransferObject["out_team_url"].ToString(),
            };

            return entity;
        }

        public static Model.Entities.WeekResult FlattenWeekResult(this Dictionary<string, object> dataTransferObject)
        {
            var result = dataTransferObject["result"].ToString();

            var entity = new Model.Entities.WeekResult
            {
                MatchUrl = dataTransferObject["match_url"].ToString(),
                Week = Convert.ToInt32(dataTransferObject["weeknumber"]),
                TeamHome = dataTransferObject["home_team"].ToString(),
                TeamHomeUrl = dataTransferObject["home_team_url"].ToString(),
                TeamAway = dataTransferObject["out_team"].ToString(),
                TeamAwayUrl = dataTransferObject["out_team_url"].ToString(),
                Result = result,
                ResultHome = result.GetResultHomeTeam(),
                ResultAway = result.GetResultAwayTeam(),
                Status = dataTransferObject["state"].ToString(),
            };

            return entity;
        }

        public static List<Model.Entities.MatrixRow> Flatten(this List<Model.DataTransferObjects.MatrixRow> dataTransferObjects)
        {
            var entities = new List<Model.Entities.MatrixRow>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.MatrixRow
                {
                    RowNumber = dataTransferObject.RowNumber,
                    Columns = dataTransferObject.Columns,
                });
            }

            return entities;
        }

        public static List<Model.Entities.Player180s> Flatten(this List<Model.DataTransferObjects.Player180s> dataTransferObjects)
        {
            var entities = new List<Model.Entities.Player180s>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                foreach (var player in dataTransferObject.Players)
                {
                    entities.Add(new Model.Entities.Player180s
                    {
                        Position = dataTransferObject.Position,
                        Name = player.Name,
                        Team = player.Team,
                        TeamUrl = player.TeamUrl,
                        Amount = player.Amount,
                        Status = player.Status,
                    });
                }
            }

            return entities;
        }

        public static List<Model.Entities.PlayerRanking> Flatten(this List<Model.DataTransferObjects.PlayerRankings> dataTransferObjects)
        {
            var entities = new List<Model.Entities.PlayerRanking>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                foreach (var player in dataTransferObject.Players)
                {
                    entities.Add(new Model.Entities.PlayerRanking
                    {
                        Position = dataTransferObject.Position,
                        Name = player.Name,
                        Team = player.Team,
                        TeamUrl = player.TeamUrl,
                        Played = player.Played,
                        Won = player.Won,
                        Percentage = player.Percentage,
                        Status = player.Status,
                    });
                }
            }

            return entities;
        }

        public static List<Model.Entities.PlayerFinish> Flatten(this List<Model.DataTransferObjects.PlayerFinishes> dataTransferObjects)
        {
            var entities = new List<Model.Entities.PlayerFinish>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                foreach (var player in dataTransferObject.Players)
                {
                    entities.Add(new Model.Entities.PlayerFinish
                    {
                        Position = dataTransferObject.Position,
                        Name = player.Name,
                        Team = player.Team,
                        TeamUrl = player.TeamUrl,
                        Finish = player.Finish,
                        Status = player.Status,
                    });
                }
            }

            return entities;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable) => new ObservableCollection<T>(enumerable);
    }
}
