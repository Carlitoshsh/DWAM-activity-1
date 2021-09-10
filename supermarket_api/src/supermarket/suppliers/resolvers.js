import { generalRequest, getRequest } from '../../utilities';
import { url, port, entryPoint, demoEndpoint } from './server';

const URLEntry = `http://${url}:${port}/${entryPoint}`;
const urlDemoMsg = `http://${url}:${port}/${demoEndpoint}`;

const resolvers = {
	Query: {
		allSuppliers: (_) =>
			getRequest(URLEntry, '')
	}
    ,
	Mutation: {
		createSupplier: (_, { supplier }) =>
			generalRequest(`${URLEntry}/`, 'POST', supplier),
		updateSupplier: (_, { id, supplier }) =>
			generalRequest(`${URLEntry}/${id}`, 'PUT', supplier),
		deleteSupplier: (_, { id }) =>
			generalRequest(`${URLEntry}/${id}`, 'DELETE'),
		countVowelsMS2: (_, { demoEntity }) =>
			generalRequest(`${urlDemoMsg}/`, 'POST', demoEntity),
	}
};

export default resolvers;
