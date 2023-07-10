using Evaluacion3PME.MVVM.Model;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.WebSockets;

namespace Evaluacion3PME;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void CounterBtn_Clicked(object sender, EventArgs e)
    {
        
        
        using (var client = new HttpClient())
        {
            var url = $"https://pokeapi.co/api/v2/pokemon-species/aegislash";

            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                var PokemonData = JsonConvert.DeserializeObject<ClaseME>(content); //JsonConvert.DeserializeObject<ClimaME>(content);
                Color.Text = PokemonData.color.name;
                EggGroup.Text = PokemonData.EggGroup.name;
                EvolvesFromSpecies.Text = PokemonData.EvolvesFromSpecies.name;
                FlavorTextEntry.Text = PokemonData.FlavorTextEntry.flavor_text;
            }
        }
    }
}

