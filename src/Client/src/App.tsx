import { useEffect, useState } from 'react';
import axios from 'axios';

interface EventDto { id: string; title: string; description: string; startDate: string; location: string; }

function App() {
  const [events, setEvents] = useState<EventDto[]>([]);
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  const [location, setLocation] = useState('');
  const [date, setDate] = useState('');

  const fetchEvents = () => { axios.get<EventDto[]>('/api/events').then(res => setEvents(res.data)); };
  useEffect(() => { fetchEvents(); }, []);

  const handleCreate = async (e: React.FormEvent) => {
    e.preventDefault();
    await axios.post('/api/events', {
      title, description, location,
      startDate: new Date(date).toISOString(),
      endDate: new Date(new Date(date).getTime() + 7200000).toISOString(),
      organizerId: "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    });
    setTitle(''); setDescription(''); setLocation(''); setDate('');
    fetchEvents();
  };

  return (
    <div className="min-h-screen bg-gray-50 p-8 font-sans text-gray-800">
      <div className="max-w-3xl mx-auto">
        <h1 className="text-4xl font-bold mb-2">EventHub</h1>
        <p className="text-gray-500 mb-8">Discover and host events in your city.</p>
        <form onSubmit={handleCreate} className="bg-white p-6 rounded-lg shadow-sm border border-gray-200 mb-8 space-y-4">
          <h2 className="text-xl font-semibold mb-4">Create an Event</h2>
          <input required placeholder="Title" value={title} onChange={e => setTitle(e.target.value)} className="w-full border p-2 rounded" />
          <input required placeholder="Description" value={description} onChange={e => setDescription(e.target.value)} className="w-full border p-2 rounded" />
          <input required placeholder="Location" value={location} onChange={e => setLocation(e.target.value)} className="w-full border p-2 rounded" />
          <input required type="datetime-local" value={date} onChange={e => setDate(e.target.value)} className="w-full border p-2 rounded" />
          <button type="submit" className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700 transition">Create Event</button>
        </form>
        <div className="space-y-4">
          {events.map(evt => (
            <div key={evt.id} className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
              <h3 className="text-2xl font-bold text-gray-900">{evt.title}</h3>
              <p className="text-gray-600 mt-2">{evt.description}</p>
              <div className="mt-4 flex gap-4 text-sm text-gray-500">
                <span>📍 {evt.location}</span>
                <span>📅 {new Date(evt.startDate).toLocaleDateString()}</span>
              </div>
            </div>
          ))}
          {events.length === 0 && <p className="text-gray-500 text-center">No events found.</p>}
        </div>
      </div>
    </div>
  );
}
export default App;
