import { generalRequest, getRequest } from '../../utilities';
import { url, port, entryPoint } from './server';

const URL = `http://${url}:${port}/${entryPoint}`;

const resolvers = {
	Query: {
		allSuppliers: (_) =>
			getRequest(URL, '')
	}
    ,
	Mutation: {
		createSupplier: (_, { supplier }) =>
			generalRequest(`${URL}/`, 'POST', supplier),
		updateSupplier: (_, { id, supplier }) =>
			generalRequest(`${URL}/${id}`, 'PUT', supplier),
		deleteSupplier: (_, { id }) =>
			generalRequest(`${URL}/${id}`, 'DELETE')
	}
};

export default resolvers;
