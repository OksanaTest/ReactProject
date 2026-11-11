import { useEffect, useState } from 'react';

// 1. Define the exact shape of your incoming backend data
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export default function App() {
  // 2. Type your state array explicitly as WeatherForecast[]
  const [forecasts, setForecasts] = useState<WeatherForecast[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  // 3. Convert componentDidMount to a modern useEffect hook
  useEffect(() => {
    async function populateWeatherData() {
      try {
        // Ensure you add the leading slash to explicitly hit the proxy mapping root
        const response = await fetch('https://localhost:7096/weatherforecast');
        //fetch('/weatherforecast') 
        const data = await response.json();
        console.log("Raw API Data arrived:", data);  //to be deleted
        setForecasts(data);
        setLoading(false);
      } catch (error) {
        console.error("Error communicating with ASP.NET Core backend:", error);
      }
    }
    populateWeatherData();
  }, []);

  // 4. Render the typed forecasts data table cleanly
  const renderForecastsTable = (data: WeatherForecast[]) => {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {data.map((forecast) => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  };

  return (
    <div>
      <h1 id="tabelLabel">Weather forecast</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {loading ? (
        <p>
          <em>
            Loading... Please refresh once the ASP.NET backend has started. See{" "}
            <a href="https://aka.ms/jspsintegrationreact">
              https://aka.ms/jspsintegrationreact
            </a>{" "}
            for more details.
          </em>
        </p>
      ) : (
        renderForecastsTable(forecasts)
      )}
    </div>
    )}