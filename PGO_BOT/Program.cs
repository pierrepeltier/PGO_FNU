using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;
using PokemonGo.RocketAPI.Rpc;
using POGOProtos.Networking.Responses;

namespace PGO_BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            MySettings settings = new MySettings();

            // Auth
            settings.AuthType = AuthType.Ptc;
            settings.PtcUsername = "Leshkalathor2";
            settings.PtcPassword = "pp230285";
            settings.DefaultAltitude = 30.356;
            settings.DefaultLatitude = 48.826053;
            settings.DefaultLongitude = 2.24750;
            
            // Login
            Client client = new Client(settings,  new MyApiFailureStrategy());
            client.Login.DoLogin().Wait();
            Console.WriteLine("Login OK");

            var player = GetPlayer(client).Result;
            Console.WriteLine("Bonjour " + player.PlayerData.Username);

            var location = UpdatePlayerLocation(client, settings.DefaultLatitude, settings.DefaultLongitude, settings.DefaultAltitude).Result;
            Console.WriteLine("Update player location");
            foreach (var pokemons in location.WildPokemons)
            {
                Console.WriteLine("Il y a un " + pokemons.PokemonData.Nickname + "sauvage qui traine !");
                // TODO client.Encounter.EncounterPokemon(pokemons.EncounterId, pokemons.SpawnPointId);
            }

            var inventory = GetInventory(client).Result;
            Console.WriteLine("Vous avez " + inventory.InventoryDelta.InventoryItems.Count + " item(s)");
            foreach (var item in inventory.InventoryDelta.InventoryItems)
            {
                var truc = item;
            }
            
            

            Console.ReadLine();
        }


        private static async Task<PlayerUpdateResponse> UpdatePlayerLocation(Client client, double lat, double lon, double alt)
        {
            return await client.Player.UpdatePlayerLocation(lat, lon, alt);
        }

        private static async Task<GetIncensePokemonResponse> GetIncensePokemons(Client client)
        {
            return await client.Map.GetIncensePokemons();
        }


        private static async Task<Tuple<GetMapObjectsResponse, GetHatchedEggsResponse, GetInventoryResponse, CheckAwardedBadgesResponse, DownloadSettingsResponse>> GetMapObjects(Client client)
        {
            return await client.Map.GetMapObjects();
        }

        private static async Task<GetPlayerResponse> GetPlayer(Client client)
        {
            return await client.Player.GetPlayer();
        }

        private static async Task<GetInventoryResponse> GetInventory(Client client)
        {
            return await client.Inventory.GetInventory();
        }

        //work when called with DoLogin(client).Wait();
        private static async Task DoLogin(Client client)
        {
            await client.Login.DoLogin();
        }

    }
}
