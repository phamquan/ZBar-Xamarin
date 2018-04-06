echo "Hello"

rm -rf /output
mkdir output

echo "Building x86 libs"
xcodebuild -project zbar.xcodeproj -target libzbar -sdk iphonesimulator -configuration Release clean build
cp build/Release-iphonesimulator/libzbar.a output/libzbar-i386.a

echo "Building arm64 libs"
xcodebuild -project zbar.xcodeproj -target libzbar -sdk iphoneos -arch arm64 -configuration Release clean build
cp build/Release-iphoneos/libzbar.a output/libzbar-arm64.a

echo "Building armv7 libs"
xcodebuild -project zbar.xcodeproj -target libzbar -sdk iphoneos -arch armv7 -configuration Release clean build
cp build/Release-iphoneos/libzbar.a output/libzbar-armv7.a

echo "Building armv7s libs"
xcodebuild -project zbar.xcodeproj -target libzbar -sdk iphoneos -arch armv7s -configuration Release clean build
cp build/Release-iphoneos/libzbar.a output/libzbar-armv7s.a

echo "Building universal libs"
lipo -create -output output/zbar-universal.a output/libzbar-i386.a output/libzbar-arm64.a output/libzbar-armv7.a output/libzbar-armv7s.a
