using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.WebSockets;
using Evaluacion3PME.Model;

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
                var PokemonData = JsonConvert.DeserializeObject<ClaseME>(content);
                Color.Text = PokemonData.color.name;
                EggGroup.Text = PokemonData.egg_groups[0].name;
                EvolvesFromSpecies.Text = PokemonData.evolves_from_species.name;
                FlavorTextEntry.Text = PokemonData.flavor_text_entries[0].flavor_text;
                FormDescription.Text = PokemonData.form_descriptions[0].description;
                Genera.Text = PokemonData.genera[0].genus;
                Generation.Text = PokemonData.generation.name;

            }
        }
    }
}

