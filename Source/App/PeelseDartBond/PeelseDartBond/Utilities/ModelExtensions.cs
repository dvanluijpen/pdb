using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using PeelseDartBond.Constants;
using PeelseDartBond.Model.Types;

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

        public static Model.Entities.Result Flatten(this Model.DataTransferObjects.Result dataTransferObject)
        {
            var entity = new Model.Entities.Result();
            entity.TeamHome = dataTransferObject.TeamHome;
            entity.TeamAway = dataTransferObject.TeamAway;
            entity.Score = dataTransferObject.Score;
            entity.Singles = dataTransferObject.Singles.Flatten();
            entity.Doubles = dataTransferObject.Doubles.Flatten();
            entity.Captains = dataTransferObject.Captains.Flatten();
            entity.Teams = dataTransferObject.Teams.Flatten();
            entity.Player180s = dataTransferObject.Player180s.Flatten();
            entity.PlayerFinishes = dataTransferObject.PlayerFinishes.Flatten();
            return entity;
        }

        public static List<Model.Entities.ResultSingle> Flatten(this List<Model.DataTransferObjects.ResultSingle> dataTransferObjects)
        {
            var entities = new List<Model.Entities.ResultSingle>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.ResultSingle
                {
                    Position = dataTransferObject.Position,
                    Home = dataTransferObject.Home,
                    Away = dataTransferObject.Away,
                    Score = dataTransferObject.Score,
                    HeaderText = Strings.HeaderTextSingles,
                });
            }

            return entities;
        }

        public static List<Model.Entities.ResultDouble> Flatten(this List<Model.DataTransferObjects.ResultDouble> dataTransferObjects)
        {
            var entities = new List<Model.Entities.ResultDouble>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.ResultDouble
                {
                    Position = dataTransferObject.Position,
                    Home1 = dataTransferObject.Home1,
                    Home2 = dataTransferObject.Home2,
                    Away1 = dataTransferObject.Away1,
                    Away2 = dataTransferObject.Away2,
                    Score = dataTransferObject.Score,
                    HeaderText = Strings.HeaderTextDoubles,
                });
            }

            return entities;
        }

        public static List<Model.Entities.ResultCaptain> Flatten(this List<Model.DataTransferObjects.ResultCaptain> dataTransferObjects)
        {
            var entities = new List<Model.Entities.ResultCaptain>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.ResultCaptain
                {
                    Position = dataTransferObject.Position,
                    Home = dataTransferObject.Home,
                    Away = dataTransferObject.Away,
                    Score = dataTransferObject.Score,
                    HeaderText = Strings.HeaderTextCaptain,
                });
            }

            return entities;
        }

        public static List<Model.Entities.ResultTeam> Flatten(this List<Model.DataTransferObjects.ResultTeam> dataTransferObjects)
        {
            var entities = new List<Model.Entities.ResultTeam>();

            foreach (var dataTransferObject in dataTransferObjects)
            {
                entities.Add(new Model.Entities.ResultTeam
                {
                    Position = dataTransferObject.Position,
                    Home = dataTransferObject.Home,
                    Away = dataTransferObject.Away,
                    Score = dataTransferObject.Score,
                    HeaderText = Strings.HeaderTextTeam,
                });
            }

            return entities;
        }

        public static List<Model.Entities.Result180> Flatten(this List<Model.DataTransferObjects.Result180> dataTransferObjects)
        {
            var entities = new List<Model.Entities.Result180>();
            var position = 0;

            foreach (var dataTransferObject in dataTransferObjects)
            {
                position += 1;
                entities.Add(new Model.Entities.Result180
                {
                    Position = position,
                    Player = dataTransferObject.Player,
                    Amount = dataTransferObject.Amount,
                    HeaderText = Strings.HeaderText180s,
                });
            }

            return entities;
        }

        public static List<Model.Entities.ResultFinish> Flatten(this List<Model.DataTransferObjects.ResultFinish> dataTransferObjects)
        {
            var entities = new List<Model.Entities.ResultFinish>();
            var position = 0;

            foreach (var dataTransferObject in dataTransferObjects)
            {
                position += 1;
                entities.Add(new Model.Entities.ResultFinish
                {
                    Position = position,
                    Player = dataTransferObject.Player,
                    Finish = dataTransferObject.Finish,
                    HeaderText = Strings.HeaderTextFinishes,
                });
            }

            return entities;
        }

        public static Color ToColor(this MatchResultType matchResultType)
        {
            return matchResultType == MatchResultType.Draw
                 ? Colors.TeamDrawFill
                 : matchResultType == MatchResultType.Win
                    ? Colors.TeamWinFill
                     : Colors.TeamLoseFill;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable) => new ObservableCollection<T>(enumerable);
    }
}
