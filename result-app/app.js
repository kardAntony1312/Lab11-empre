const express = require('express');
const { Pool } = require('pg');

const app = express();
const pool = new Pool({
  user: 'postgres',
  host: 'db',
  database: 'recommender',
  password: 'postgres',
  port: 5432,
});

app.get('/results', async (req, res) => {
  try {
    const result = await pool.query('SELECT * FROM recommendations');
    res.json(result.rows);
  } catch (error) {
    console.error(error);
    res.status(500).send('Error retrieving results');
  }
});

app.listen(3000, () => {
  console.log('Result app listening on port 3000');
});
