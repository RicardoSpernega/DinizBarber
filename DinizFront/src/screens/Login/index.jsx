import React , {useEffect, useState} from 'react';
import { View, Text, Button, Thumbnail, Content, Form, Item, Input, Label } from 'native-base';
import { Alert, StyleSheet, Dimensions, ImageBackground } from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';
import {api} from '../../utils/api'
import LinearGradient from 'react-native-linear-gradient';
import { COLOR, Styles } from '../../config/styles';
import { SafeAreaView, ScrollView } from 'react-native';
import {Style} from './styles'
import { Hr } from '../../components';
import { useNavigation } from '@react-navigation/native';
import { useDispatch } from 'react-redux';
import { Types } from '../../store/ducks/authenticate';

const gradientProps = {
  start: { x: 1, y: 0 },
  end: { x: 1, y: 1 },
  colors: [COLOR.DANGER, 'rgb(255, 185, 185)']
};

const logoProps = {
  style: Style.logoLogin,
  source: require('../../assets/logo.png'),
  square: true,
};

const navioProps = {
  style: Style.fundoNavio,
  source: require('../../assets/ship-opacity.png'),
  square: true,
};

const style = StyleSheet.create({
  container: {
    height: Dimensions.get('window').height,
    width: Dimensions.get('window').width,
    alignItems: 'center',
  },
 });

export function LoginScreen() {
  const navigation = useNavigation();
  
  const [email, setEmailLogin] = useState('')
  const [password, setSenhaLogin] = useState('')
  const dispatch = useDispatch();

  useEffect(() => {
  }, [])

  function login() {  
    // let url = '/api/Authenticate/Login'
    // const body = {
    //   email,
    //   password
    // }
    // api('').post(url, body)
    // .then(({ data: {token} }) => {
      navigation.navigate('Monitoramento')
      // AsyncStorage.setItem('email', email)
    //   dispatch({type: Types.LOGAR, email, token})
    // })
    // .catch(err => Alert.alert('Login ou senha inválido(s).'));
  }

  return (
    <LinearGradient {...gradientProps}>
      <ScrollView>
        <SafeAreaView style={style.container}>
          <View style={Style.boxLogin}>
              <Thumbnail {...logoProps} />    
              <Hr/>
              <Text style={Style.title}>DINIZ BARBER SHOP</Text>
              <Item style={{marginTop: 10, borderColor: 'transparent'}} stackedLabel regular last>
                <Label style={Style.label}>Email</Label>
                <Input style={Style.input} onChangeText={value => setEmailLogin(value)}/>
              </Item>
              <Item style={{marginTop: 10, borderColor: 'transparent'}} stackedLabel regular last >
                <Label style={Style.label}>Senha</Label>
                <Input secureTextEntry={true} style={Style.input} onChangeText={value => setSenhaLogin(value)}/>
              </Item>
              <Text style={{alignSelf: 'flex-end', marginRight: 30,fontSize: 14}}>Esqueceu sua senha?</Text>
              <Button style={Style.btnEntrar} onPress={() => login()}><Text style={{textAlign: "center"}}>Entrar</Text></Button>
              <Text style={{alignSelf: 'center'}}>ou</Text>
              <Button style={Style.btnCadastro} onPress={() => login()}><Text style={{textAlign: "center"}}>Cadastre-se</Text></Button>
          </View>
          {/* <ImageBackground source={require('../../assets/ship-opacity.png')} style={{ width: Dimensions.get('window').width, height: 100, marginTop: -20 }}/> */}
        </SafeAreaView>
      </ScrollView>
    </LinearGradient>
  )
}