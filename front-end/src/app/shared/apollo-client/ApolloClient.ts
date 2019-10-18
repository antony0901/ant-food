import { ApolloClient } from 'apollo-client';
import { createHttpLink } from 'apollo-link-http'
import { setContext } from 'apollo-link-context'
import { InMemoryCache } from 'apollo-cache-inmemory';
import { onError } from 'apollo-link-error';
import { ApolloLink } from 'apollo-link';
import { store } from '../../store';

const httpLink = createHttpLink({
  uri: process.env.REACT_APP_API_URI
});

const errorLink = onError(({ networkError, graphQLErrors }) => {
  if (graphQLErrors) {
    graphQLErrors.map(({ message }) => {
      console.error(message);
    });
  }
});

const authLink = setContext((_: any, { headers }: any) => {
  const token = localStorage.getItem(process.env.REACT_APP_ACCESS_TOKEN || '');
  return {
    headers: {
      ...headers,
      authorization: token ? `Bearer ${token}` : '',
    }
  };
});

const link = ApolloLink.from([
  errorLink,
  authLink.concat(httpLink),
]);

const client = new ApolloClient({
  link,
  cache: new InMemoryCache(),
});

export default client;