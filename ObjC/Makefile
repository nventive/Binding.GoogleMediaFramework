XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/GoogleMediaFramework.xcodeproj
TARGET=GoogleMediaFramework

all: libGoogleMediaFrameworkSDK.a

libGoogleMediaFramework-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libGoogleMediaFramework-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libGoogleMediaFramework-armv6.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv6 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libGoogleMediaFramework-armv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libGoogleMediaFramework-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libGoogleMediaFrameworkSDK.a: libGoogleMediaFramework-i386.a libGoogleMediaFramework-armv7.a libGoogleMediaFramework-armv7s.a libGoogleMediaFramework-armv6.a libGoogleMediaFramework-arm64.a
	xcrun -sdk iphoneos lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll