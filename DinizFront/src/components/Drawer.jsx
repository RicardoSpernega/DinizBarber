import React from 'react';
import 'react-native-gesture-handler';
import { DrawerItemList, DrawerItem, DrawerContentScrollView } from '@react-navigation/drawer';
import { View, Thumbnail, Text, Icon} from 'native-base';
import { Styles } from '../config/styles';
import { SafeAreaView, ScrollView } from 'react-native';
import { COLOR } from '../config/styles';
import { useNavigation } from '@react-navigation/native';
import { TouchableOpacity } from 'react-native-gesture-handler';
import { verticalScale } from 'react-native-size-matters';

const logoProps = {
    style: Styles.logo,
    source: require('../assets/logo-modal.png'),
    square: true,
};

const avatarProps = {
    source: require('../assets/logo-modal.png'),
    square: true
};

export const Drawer = props => {
    const { navigation: { navigate } } = props;

    // const navItem = (nav, text) => {

    //     return (
    //       <TouchableOpacity
    //         style={Styles.touchableNavLink}
    //         onPress={() => navigation.navigate(nav)}>
    //         <Text style={Styles.textNavLink}>{text}</Text>
    //       </TouchableOpacity>
    //     );
    //   }

    return (
    <SafeAreaView style={{ flex: 1 }} forceInset={{ top: 'always', horizontal: 'never' }}>
        <DrawerContentScrollView {...props} style={Styles.container}>
            <View style={Styles.header}>
                <View style={Styles.userInfo}>
                    <View>
                        <Text style={Styles.title}>MENU</Text>
                    </View>
                </View>
            </View>

        <TouchableOpacity style={Styles.drawerItem}>
        <Icon name="home" type="FontAwesome5" style={Styles.drawerIcon} />
        <DrawerItem {...props} label='Home' onPress={() => navigate('Monitoramento')} labelStyle={Styles.drawerLabel} />
        </TouchableOpacity>

        <TouchableOpacity style={Styles.drawerItem} onPress={() => navigate('Condicoes')}>
        <Icon name="calendar-clock" type="MaterialCommunityIcons" style={Styles.drawerIcon} />
        <DrawerItem {...props} label='Agendamento' labelStyle={Styles.drawerLabel} />
        </TouchableOpacity>

        {/* <TouchableOpacity style={Styles.drawerItem} onPress={() => navigate('Passagens')}>
        <Icon name="restore-clock" type="MaterialCommunityIcons" style={Styles.drawerIcon} />
        <DrawerItem {...props} label='Histórico de Passagens' labelStyle={Styles.drawerLabel} />
        </TouchableOpacity> */}

        {/* <TouchableOpacity style={Styles.drawerItem} onPress={() => navigate('Trafego')}>
        <Icon name="earth" type="MaterialCommunityIcons" style={Styles.drawerIcon} />
        <DrawerItem {...props} label='Histórico de Tráfego' labelStyle={Styles.drawerLabel} />
        </TouchableOpacity>

        <TouchableOpacity style={Styles.drawerItem} onPress={() => navigate('Alertas')}>
        <Icon name="bell" type="MaterialCommunityIcons" style={Styles.drawerIcon} labelStyle={Styles.drawerLabel} />
        <DrawerItem {...props} label='Histórico de Alertas' labelStyle={Styles.drawerLabel} />
        </TouchableOpacity> */}

        <TouchableOpacity style={[Styles.drawerItem, { marginTop: verticalScale(300) }]} onPress={() => navigate('Login')}>
        <Icon name="exit-to-app" type="MaterialCommunityIcons" style={Styles.drawerIcon} labelStyle={Styles.drawerLabel} />
        <DrawerItem {...props} label='Sair' labelStyle={Styles.drawerLabel} />
        </TouchableOpacity>
        </DrawerContentScrollView>
    </SafeAreaView>
    )
}