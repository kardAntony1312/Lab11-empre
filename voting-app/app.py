from flask import Flask, request, jsonify
import redis

app = Flask(__name__)

# Configurar la conexión a Redis
redis_client = redis.Redis(host='redis', port=6379, decode_responses=True)

@app.route('/vote', methods=['POST'])
def vote():
    data = request.json
    movie_id = data.get('movie_id')
    user_id = data.get('user_id')
    if movie_id and user_id:
        redis_client.lpush('votes', f"{user_id}:{movie_id}")
        return jsonify({'message': 'Vote received'}), 200
    return jsonify({'error': 'Invalid input'}), 400

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)
