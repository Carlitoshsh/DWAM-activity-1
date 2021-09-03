import { generalRequest, getRequest } from '../../utilities';
import { url, port, entryPoint } from './server';

const URL = `http://${url}:${port}/${entryPoint}`;

const resolvers = {
	Query: {
		allSamples: (_) =>
			getRequest(URL, '')
	}
    ,
	Mutation: {
		createSample: (_, { sample }) =>
			generalRequest(`${URL}/`, 'POST', sample),
		updateSample: (_, { id, sample }) =>
			generalRequest(`${URL}/${id}`, 'PUT', sample),
		deleteSample: (_, { id }) =>
			generalRequest(`${URL}/${id}`, 'DELETE')
	}
};

export default resolvers;
