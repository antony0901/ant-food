import React from 'react';
import {
  ApplicationProvider,
  Button,
  Icon,
  IconRegistry,
  Layout,
  Text,
} from 'react-native-ui-kitten';
import { StyleSheet, ImageStyle, ImageProps } from 'react-native';

/**
 * Use any valid `name` property from eva icons (e.g `github`, or `heart-outline`)
 * https://akveo.github.io/eva-icons
 */
const HeartIcon = (style: ImageStyle): React.ReactElement<ImageProps> => (
  <Icon {...style} name='heart'/>
);

interface HomeContainerProps {

}

const HomeContainer = (props: HomeContainerProps) => {
  return (
    <React.Fragment>
      <Text style={styles.text} category='h1'>
          Welcome to UI Kitten 😻
      </Text>
      <Text style={styles.text} category='s1'>
        Start with editing App.js to configure your App
      </Text>
      <Text style={styles.text} appearance='hint'>
        For example, try changing theme to Dark by simply changing an import
      </Text>
      <Button style={styles.likeButton} icon={HeartIcon}>
        LIKE
      </Button>
    </React.Fragment>
  )
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  text: {
    textAlign: 'center',
  },
  likeButton: {
    marginVertical: 16,
  },
});

export default HomeContainer;